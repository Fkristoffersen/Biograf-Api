using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BiografApi.Models;

namespace BiografApi.Controllers
{
    public class MessageController : ApiController
    {
        [AcceptVerbs("POST")]
        [Route("api/Message/Create")]
        [HttpGet]
        public HttpResponseMessage Post(string Firstname, string Lastname, string Email, string Msg)
        {

            string query = $"EXEC NEW_MESSAGE " +
                $"@Firstname = '{Firstname}', @Lastname= '{Lastname}', @Email = '{Email}', @Msg= '{Msg}'";


            DataTable dt = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CinemaApp"].ConnectionString))
            {
                using (var cmd = new SqlCommand(query, con))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        da.Fill(dt);
                    }
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, dt);

        }
        
        

    }
}
