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
    public class TicketController : ApiController
    {
        [Route("api/Ticket/GetAll")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            string query = @"EXEC ALL_TICKET";
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

        [Route("api/Ticket/GetSingle")]
        [HttpGet]
        public HttpResponseMessage GetSingle(int id)
        {
            string query = $"EXEC THE_TICKET @CustomerID = {id}";
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
        [Route("api/Ticket/Post")]
        public HttpResponseMessage Post(int CustomerID, int ReservationID, int ScreeningID, int OrderID)
        {

            string query = $"EXEC NEW_TICKET " +
                $"@CustomerID = '{CustomerID}', @ReservationID = '{ReservationID}', @ScreeningID = '{ScreeningID}', @OrderID = '{OrderID}'";


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
        [Route("api/Ticket/Put")]
        public HttpResponseMessage Put(int TicketID, int CustomerID, int ReservationID, int ScreeningID, int OrderID)
        {

            string query = $"EXEC UPDATE_TICKET " +
                            $"@TicketID  = '{TicketID}', @CustomerID  = '{CustomerID}', @ReservationID = '{ReservationID}', @ScreeningID = '{ScreeningID}', @OrderID = '{OrderID}'";


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
        [Route("api/Ticket/Delete")]
        public HttpResponseMessage Delete(int id)
        {
            string query = $"EXEC DEL_TICKET @TicketID = {id}";

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
