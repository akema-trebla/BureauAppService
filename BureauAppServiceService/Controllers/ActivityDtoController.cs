using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using BureauAppServiceService.DataObjects;
using BureauAppServiceService.Models;
using BureauAppServiceService.Infrastructure;

namespace BureauAppServiceService.Controllers
{
    public class ActivityDtoController : TableController<ActivityDto>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            Business1DbContext context = new Business1DbContext();
            DomainManager = new CustomEntityDomainManager<ActivityDto, Activity, int>(context, Request, key => ce => ce.ActivityID == key);
        }


        // GET tables/ActivityDto
        public IQueryable<ActivityDto> GetAllActivityDto()
        {
            return Query(); 
        }

        // GET tables/ActivityDto/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<ActivityDto> GetActivityDto(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/ActivityDto/48D68C86-6EA6-4C25-AA33-223FC9A27959
        [Authorize]
        public Task<ActivityDto> PatchActivityDto(string id, Delta<ActivityDto> patch)
        {
             return base.UpdateAsync(id, patch);
        }

        // POST tables/ActivityDto
        [Authorize]
        public async Task<IHttpActionResult> PostActivityDto(ActivityDto item)
        {
            ActivityDto current = await InsertAsync(item);
            return base.CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/ActivityDto/48D68C86-6EA6-4C25-AA33-223FC9A27959
        [Authorize]
        public Task DeleteActivityDto(string id)
        {
             return base.DeleteAsync(id);
        }
    }
}
