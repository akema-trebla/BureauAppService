using AutoMapper;
using BureauAppServiceService.DataObjects;
using BureauAppServiceService.Models;
using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;

namespace BureauAppServiceService.Infrastructure
{
    public class ActivityDtoDomainManager : MappedEntityDomainManager<ActivityDto, Activity>
    {
         private Business1DbContext context;

        public ActivityDtoDomainManager(Business1DbContext context, HttpRequestMessage request)
            : base(context, request)
        {
            Request = request;
            this.context = context;
        }

        public static int GetKey(string activityDtoId, DbSet<Activity> activities, HttpRequestMessage request)
        {
            int activityId = activities
               .Where(c => c.ActivityID.ToString() == activityDtoId)
               .Select(c => c.ActivityID)
               .FirstOrDefault();

            if (activityId == 0)
            {
                throw new HttpResponseException(request.CreateNotFoundResponse());
            }
            return activityId;
        }

        protected override T GetKey<T>(string activityDtoId)
        {
            return (T)(object)GetKey(activityDtoId, this.context.Activities, this.Request);
        }

        public override SingleResult<ActivityDto> Lookup(string activityDtoId)
        {
            int activityId = GetKey<int>(activityDtoId);
            return LookupEntity(c => c.ActivityID == activityId);
        }

        public override async Task<ActivityDto> InsertAsync(ActivityDto activityDto)
        {
            return await base.InsertAsync(activityDto);
        }

        public override async Task<ActivityDto> UpdateAsync(string activityDtoId, Delta<ActivityDto> patch)
        {
            int activityId = GetKey<int>(activityDtoId);

            Activity existingActivity = await this.Context.Set<Activity>().FindAsync(activityId);
            if (existingActivity == null)
            {
                throw new HttpResponseException(this.Request.CreateNotFoundResponse());
            }

            ActivityDto existingActivityDto = Mapper.Map<Activity, ActivityDto>(existingActivity);
            patch.Patch(existingActivityDto);
            Mapper.Map<ActivityDto, Activity>(existingActivityDto, existingActivity);

            await this.SubmitChangesAsync();

            ActivityDto updatedActivityDto = Mapper.Map<Activity, ActivityDto>(existingActivity);

            return updatedActivityDto;
        }

        public override async Task<ActivityDto> ReplaceAsync(string activityDtoId, ActivityDto activityDto)
        {
            return await base.ReplaceAsync(activityDtoId, activityDto);
        }

        public override async Task<bool> DeleteAsync(string activityDtoId)
        {
            int activityId = GetKey<int>(activityDtoId);
            return await DeleteItemAsync(activityId);
        }
    }
}