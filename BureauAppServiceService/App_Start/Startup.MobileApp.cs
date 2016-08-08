using BureauAppServiceService.DataObjects;
using BureauAppServiceService.Infrastructure;
using BureauAppServiceService.Models;
using BureauAppServiceService.Providers;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace BureauAppServiceService
{
    public partial class Startup
    {
        public void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            //AutoMapper.Mapper.Initialize(cfg =>
            //{
            //    // Define a map from the client type to the database type. Used when inserting and updating data.
            //    cfg.CreateMap<ActivityDto, Activity>()
            //        .ForMember(ce => ce.ActivityID,
            //        map => map.MapFrom(dto => int.Parse(dto.Id))
            //        );
            //    cfg.CreateMap<ProjectTaskDto, ProjectTask>()
            //        .ForMember(ce => ce.TaskID,
            //        map => map.MapFrom(dto => int.Parse(dto.Id))
            //        );

            //    // Define a map from the database type User to client type UserDto. Used when getting data.
            //    cfg.CreateMap<Activity, ActivityDto>()
            //         .ForMember(dto => dto.Id, 
            //         map => map.MapFrom(ce => ce.ActivityID.ToString())
            //         );
            //    cfg.CreateMap<ProjectTask, ProjectTaskDto>()
            //         .ForMember(dto => dto.Id, 
            //         map => map.MapFrom(ce => ce.TaskID.ToString())
            //         );
            //    ;
                 
            //});
            // Using X-ZUMO-AUTH 
            //ConfigureCustomAuth(app);

            ConfigureOAuthTokenGeneration(app);

            ConfigureOAuthTokenConsumption(app);

            ConfigureWebApi(config);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            //For more information on Web API tracing, see http://go.microsoft.com/fwlink/?LinkId=620686 
            config.EnableSystemDiagnosticsTracing();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            // Use Entity Framework Code First to create database tables based on your DbContext
              ////Database.SetInitializer(new Business1DbInitializer());

            // To prevent Entity Framework from modifying your database schema, use a null database initializer
            // Database.SetInitializer<BureauAppServiceContext>(null);

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                // This middleware is intended to be used locally for debugging. By default, HostName will
                // only have a value when running in an App Service application.
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }
            app.UseWebApi(config);

           // ConfigureDbMigration();
        }
        private void ConfigureCustomAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);


            OAuthAuthorizationServerOptions oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new PathString("/oauth/token"),
                Provider = new CustomOAuthProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                AccessTokenFormat = new CustomZumoTokenFormat(),
            };

            // OAuth Configuration
            app.UseOAuthAuthorizationServer(oAuthServerOptions);

        }

        private void ConfigureOAuthTokenConsumption(IAppBuilder app)
        {
            var issuer = "http://localhost:59822";
            string audienceId = ConfigurationManager.AppSettings["as:AudienceId"];
            byte[] audienceSecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["as:AudienceSecret"]);

            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audienceId },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, audienceSecret)
                    }
                });

        }

        private void ConfigureDbMigration()
        {
            throw new NotImplementedException();

            //DbMigrator businessMigrator = new DbMigrator(new BusinessConfiguration());
            //businessMigrator.Update();

            //DbMigrator applicationMigrator = new DbMigrator(new ApplicationConfiguration());
            //applicationMigrator.Update();

        }

        private void ConfigureOAuthTokenGeneration(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

            // Plugin the OAuth bearer JSON Web Token tokens generation and Consumption will be here
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                //For Dev enviroment only (on production should be AllowInsecureHttp = false)
                AllowInsecureHttp = false,
                TokenEndpointPath = new PathString("/oauth/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new CustomOAuthProvider(),
                AccessTokenFormat = new CustomJwtFormat("http://localhost:59822")
            };

            // OAuth 2.0 Bearer Access Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
        }


        //public class Business1DbInitializer : ClearDatabaseSchemaIfModelChanges<Business1DbContext>
        //{
        //    protected override void Seed(Business1DbContext context)
        //    {
        //        List<Activity> activities = new List<Activity>
        //        {
        //            new Activity { Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false },
        //            new Activity { Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false },
        //        };

        //        foreach (Activity activity in activities)
        //        {
        //            context.Set<Activity>().Add(activity);
        //        }

        //        base.Seed(context);
        //    }
        //}

        private void ConfigureWebApi(HttpConfiguration httpconfig)
        {
            httpconfig.MapHttpAttributeRoutes();

            var jsonFormatter = httpconfig.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
