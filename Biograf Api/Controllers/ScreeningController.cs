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
    public class ScreeningController : ApiController
    {
        [Route("api/Screening/GetAll")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            string query = @"EXEC ALL_SCREENING";
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

        [Route("api/Screening/GetSingle")]
        [HttpGet]
        public HttpResponseMessage GetSingle(int id)
        {
            string query = $"EXEC THE_SCREENING @FilmID = {id}";
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
        [Route("api/Screening/Post")]
        public HttpResponseMessage post(int Hall, string Date, string Time, int FilmID)
        {
            string query = $"EXEC NEW_SCREENING " +
                  $"@Hall = '{Hall}', @Date = '{Date}', @Time = '{Time}', @FilmID = '{FilmID}'";

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
        [Route("api/Screening/Put")]
        public HttpResponseMessage Put(int ScreeningID,int Hall, string Date, string Time, int FilmID)
        {
            string query = $"EXEC UPDATE_SCREENING " +
                $"@ScreeningID = '{ScreeningID}', @Hall = '{Hall}', @Date = '{Date}', @Time = '{Time}', @FilmID = '{FilmID}'";


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
        [Route("api/Screening/Delete")]        
        public HttpResponseMessage Delete(int id)
        {
  
            string query = $"EXEC DELETE_SCREENING @ScreeningID = '{id}'";

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
