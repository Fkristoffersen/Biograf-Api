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
    public class FilmController : ApiController
    {
        [Route("api/Film/GetAll")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            string query = @"EXEC SELECTALL_FILM";
            DataTable table = new DataTable();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CinemaApp"].ConnectionString))
            {
                using (var cmd = new SqlCommand(query, con))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        da.Fill(table);
                    }
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        [Route("api/Film/GetSingle")]
        [HttpGet]
        public HttpResponseMessage getsingle(int id)
        {

            string query =
                     $"EXEC SELECTSINGLE_FILM @FilmID = {id}";
            DataTable table = new DataTable();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CinemaApp"].ConnectionString))
            using (var cmd = new SqlCommand(query, con)) 
            using (var da = new SqlDataAdapter(cmd)) 
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }



        [AcceptVerbs("POST")]
        [System.Web.Http.HttpGet]
        [Route("api/Film/Post")]
        public HttpResponseMessage Post(string Titel, string RunTime, string StartDate, string EndDate, string Picture)
        {
            
                string query = $"EXEC NEW_FILM " +
                    $"@Titel = '{Titel}', @RunTime = '{RunTime}', @StartDate = '{StartDate}', @EndDate = '{EndDate}', @Picture = '{Picture}'";


                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CinemaApp"].ConnectionString))
                {
                    using (var cmd = new SqlCommand(query, con))
                    {
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.Text;
                            da.Fill(table);
                        }
                    }
                }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }



        [AcceptVerbs("PUT")]
        [System.Web.Http.HttpGet]
        [Route("api/Film/Put")]
        public HttpResponseMessage Put(int FilmID, string Titel, string RunTime, DateTime StartDate, DateTime EndDate,string Picture)
        {
            

                string query = $"EXEC UPDATE_FILM " +
                               $"@FilmID = {FilmID}, @Titel = '{Titel}', @RunTime = '{RunTime}', @StartDate = '{StartDate}', @EndDate = '{EndDate}', @Picture = '{Picture}'";


                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CinemaApp"].ConnectionString))
                {
                    using (var cmd = new SqlCommand(query, con))
                    {
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.Text;
                            da.Fill(table);
                        }
                    }
                }
            return Request.CreateResponse(HttpStatusCode.OK, table);

        }



        [AcceptVerbs("DELETE")]
        [System.Web.Http.HttpGet]
        [Route("api/Film/Delete")]
        public HttpResponseMessage Delete(int FilmID)
        {
            

                string query = $"EXEC DELETE_FILM @FilmID = {FilmID}";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CinemaApp"].ConnectionString))
                {
                    using (var cmd = new SqlCommand(query, con))
                    {
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.Text;
                            da.Fill(table);
                        }
                    }
                }
            return Request.CreateResponse(HttpStatusCode.OK, table);

        }
    }
}
