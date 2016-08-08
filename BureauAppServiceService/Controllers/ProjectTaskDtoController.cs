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
    public class ProjectTaskDtoController : TableController<ProjectTaskDto>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            Business1DbContext context = new Business1DbContext();
            DomainManager = new CustomEntityDomainManager<ProjectTaskDto, ProjectTask, int>(context, Request, key => ce => ce.TaskID == key);
        }

        // GET tables/ProjectTaskDto
        public IQueryable<ProjectTaskDto> GetAllProjectTaskDto()
        {
            return Query(); 
        }

        // GET tables/ProjectTaskDto/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<ProjectTaskDto> GetProjectTaskDto(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/ProjectTaskDto/48D68C86-6EA6-4C25-AA33-223FC9A27959
        [Authorize]
        public Task<ProjectTaskDto> PatchProjectTaskDto(string id, Delta<ProjectTaskDto> patch)
        {
             return base.UpdateAsync(id, patch);
        }

        // POST tables/ProjectTaskDto
        [Authorize]
        public async Task<IHttpActionResult> PostProjectTaskDto(ProjectTaskDto item)
        {
            ProjectTaskDto current = await InsertAsync(item);
            return base.CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/ProjectTaskDto/48D68C86-6EA6-4C25-AA33-223FC9A27959
        [Authorize]
        public Task DeleteProjectTaskDto(string id)
        {
             return base.DeleteAsync(id);
        }
    }
}
