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
    public class ProjectTaskDtoDomainManager : MappedEntityDomainManager<ProjectTaskDto, ProjectTask>
    {
         private Business1DbContext context;

         public ProjectTaskDtoDomainManager(Business1DbContext context, HttpRequestMessage request)
            : base(context, request)
        {
            Request = request;
            this.context = context;
        }

         public static int GetKey(string projectTaskDtoId, DbSet<ProjectTask> projectTasks, HttpRequestMessage request)
         {
             int projectTaskId = projectTasks
                .Where(c => c.TaskID.ToString() == projectTaskDtoId)
                .Select(c => c.TaskID)
                .FirstOrDefault();

             if (projectTaskId == 0)
             {
                 throw new HttpResponseException(request.CreateNotFoundResponse());
             }
             return projectTaskId;
         }

         protected override T GetKey<T>(string projectTaskDtoId)
         {
             return (T)(object)GetKey(projectTaskDtoId, this.context.ProjectTasks, this.Request);
         }

         public override SingleResult<ProjectTaskDto> Lookup(string projectTaskDtoId)
         {
             int projectTaskId = GetKey<int>(projectTaskDtoId);
             return LookupEntity(c => c.TaskID == projectTaskId);
         }

         public override async Task<ProjectTaskDto> InsertAsync(ProjectTaskDto projectTaskDto)
         {
             return await base.InsertAsync(projectTaskDto);
         }

         public override async Task<ProjectTaskDto> UpdateAsync(string projectTaskDtoId, Delta<ProjectTaskDto> patch)
         {
             int projectTaskId = GetKey<int>(projectTaskDtoId);

             ProjectTask existingProjectTask = await this.Context.Set<ProjectTask>().FindAsync(projectTaskId);
             if (existingProjectTask == null)
             {
                 throw new HttpResponseException(this.Request.CreateNotFoundResponse());
             }

             ProjectTaskDto existingProjectTaskDto = Mapper.Map<ProjectTask, ProjectTaskDto>(existingProjectTask);
             patch.Patch(existingProjectTaskDto);
             Mapper.Map<ProjectTaskDto, ProjectTask>(existingProjectTaskDto, existingProjectTask);

             await this.SubmitChangesAsync();

             ProjectTaskDto updatedProjectTaskDto = Mapper.Map<ProjectTask, ProjectTaskDto>(existingProjectTask);

             return updatedProjectTaskDto;
         }

         public override async Task<ProjectTaskDto> ReplaceAsync(string projectTaskDtoId, ProjectTaskDto projectTaskDto)
         {
             return await base.ReplaceAsync(projectTaskDtoId, projectTaskDto);
         }

         public override async Task<bool> DeleteAsync(string projectTaskDtoId)
         {
             int projectTaskId = GetKey<int>(projectTaskDtoId);
             return await DeleteItemAsync(projectTaskId);
         }
    }
}