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
    public class ReservationController : ApiController
    {
        [Route("api/Reservation/GetAll")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            string query = @"EXEC ALL_RESERVATION";
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


        [HttpGet]
        [Route("api/Reservation/GetSingle")]
        public HttpResponseMessage GetSingle(int id)
        {
            string query = $"EXEC THE_RESERVATION @ReservationID = {id}";
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


        [HttpGet]
        [Route("api/Reservation/GetCus")]
        public HttpResponseMessage GetTheCus(int id)
        {
            string query = $"EXEC CUSTOMER_RESERVATION @CustomerID = {id}";
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
        [Route("api/Reservation/Post")]
        public HttpResponseMessage Post(int SeatID, int ScreeningID, int CustomerID)
        {

            string query = $"EXEC NEW_RESERVATION " +
                $"@SeatID = '{SeatID}', @ScreeningID = '{ScreeningID}', @CustomerID = '{CustomerID}'";


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
        [Route("api/Reservation/Put")]
        public HttpResponseMessage Put(int ReservationID ,int SeatID, int ScreeningID, int CustomerID)
        {

            string query = $"EXEC UPDATE_RESERVATION " +
                            $"@reservationID = '{ReservationID}', @SeatID = '{SeatID}', @ScreeningID = '{ScreeningID}', @CustomerID = '{CustomerID}'";


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
        [Route("api/Reservation/Delete")]
        public HttpResponseMessage Delete(int id)
        {

            string query = $"EXEC DEL_RESERVATION @ReservationID = {id}";

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
