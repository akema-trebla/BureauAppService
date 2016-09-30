using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using BureauAppServiceService.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace BureauAppServiceService.Controllers
{
    [MobileAppController]
    public class MyController : ApiController
    {
        // GET api/My
        public string Get()
        {
            return "Hello from custom controller!";
        }

        // POST api/my
        public int Post()
        {
            using (Business1DbContext context = new Business1DbContext())
            {
                // Get the database from the context.
                var database = context.Database;

                //
               //SqlParameter Param1 = new SqlParameter("@Basic_Salary", 5);

               //SqlParameter Param2 = new SqlParameter("@PayrollrunID", 2);

               var result = database.ExecuteSqlCommand("sp_update_Basic_Salary_in_Payrollrun @Basic_Salary = {0}, @PayrollrunID = {1}", 5, 2
                   //Param1, Param2
                   );
               return result;
            }
        }
    }
}
