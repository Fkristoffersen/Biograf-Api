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
    public class AdminController : ApiController
    {
        [Route("api/Admin/GetAll")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            string query = @"EXEC ALL_ADMIN";
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

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpGet]
        [Route("api/Admin/Post")]
        public HttpResponseMessage Post(string Firstname, string Lastname, string Email, string Password)
        {

            string query = $"EXEC NEW_ADMIN " +
                $"@Firstname = '{Firstname}', @Lastname = '{Lastname}', @Email  = '{Email}', @Password = '{Password}'";


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


        [System.Web.Http.AcceptVerbs("PUT")]
        [System.Web.Http.HttpGet]
        [Route("api/Admin/Put")]
        public HttpResponseMessage Put(int AdminID,string Firstname, string Lastname, string Email, string Password)
        {

            string query = $"EXEC UPDATE_ADMIN " +
                            $"@AdminID  = '{AdminID}', @Firstname = '{Firstname}', @Lastname = '{Lastname}', @Email = '{Email}', @Password = '{Password}'";


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
        [System.Web.Http.AcceptVerbs("DELETE")]
        [System.Web.Http.HttpGet]
        [Route("api/Admin/Delete")]
        public HttpResponseMessage Delete(int id)
        {


            string query = $"EXEC DEL_ADMIN @AdminID = {id}";

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
