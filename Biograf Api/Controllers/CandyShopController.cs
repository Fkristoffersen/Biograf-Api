using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Biograf_Api.Models;
using System.Web.Http.Cors;

namespace Biograf_Api.Controllers
{
    public class CandyShopController : ApiController
    {


        public CandyShop Candy; 

        [EnableCors(origins: "http://localhost:62272", headers: "*", methods: "*")]

        // Får fra table CandyShop og fylder et DataTable med det data.

        [HttpGet]
        [Route("api/CandyShop/GetAll")]
        public HttpResponseMessage Get()
        {
            string query =
                     @"EXEC SELECTALL_CANDY";
            DataTable table = new DataTable();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CinemaApp"].ConnectionString))
            using (var cmd = new SqlCommand(query, con)) //SqlCommand tilader brugen af sql queries.
            using (var da = new SqlDataAdapter(cmd)) //SqlDataAdapter bruges til lægge data i DataSet(kasser) og opdatere "Data Source".
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table); //Sender statuskode og DataTable.
        }

        [HttpGet]
        [Route("api/CandyShop/GetSingle")]
        public HttpResponseMessage getsingle(int id)
        {
            
            string query =
                     $"EXEC SELECTSINGLE_CANDY @CandyID = {id}";
            DataTable table = new DataTable();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CinemaApp"].ConnectionString))
            using (var cmd = new SqlCommand(query, con)) //SqlCommand tilader brugen af sql queries.
            using (var da = new SqlDataAdapter(cmd)) //SqlDataAdapter bruges til lægge data i DataSet(kasser) og opdatere "Data Source".
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table); //Sender statuskode og DataTable.
        }
        //indsætte ind i table candyshop table
        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpGet]
        [Route("api/CandyShop/Post")]
        public HttpResponseMessage Post(string Name, string Size, int Price,  string Picture)
        {
           
                string query = $"EXEC NEW_CANDY " +
                    $"@Name = '{Name}', @Size = '{Size}', @Price = '{Price}', @Picture = '{Picture}'";

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

        //For at opdaterer Table CandyShop.
        [System.Web.Http.AcceptVerbs("PUT")]
        [System.Web.Http.HttpGet]
        [Route("api/CandyShop/Put")]
        public HttpResponseMessage Put(int CandyID,string Name,string Size, int Price, string Picture)
        {
            
                string query = $"EXEC UPDATE_CANDY " +
                                $"@CandyID = '{CandyID}', @Name = '{Name}', @Size = '{Size}', @Price = '{Price}', @Picture = '{Picture}'" ;
                
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

        [System.Web.Http.AcceptVerbs("DELETE")]
        [System.Web.Http.HttpGet]
        [Route("api/CandyShop/Delete")]
        public HttpResponseMessage Delete(int id)
        {

            string query =
                      $"EXEC DELETE_CANDY @CandyID = {id}";
            DataTable table = new DataTable();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CinemaApp"].ConnectionString))
            using (var cmd = new SqlCommand(query, con)) //SqlCommand tilader brugen af sql queries.
            using (var da = new SqlDataAdapter(cmd)) //SqlDataAdapter bruges til lægge data i DataSet(kasser) og opdatere "Data Source".
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
             
            }

            return Request.CreateResponse(HttpStatusCode.OK, table); //Sender statuskode og DataTable.
        }


        //[HttpDelete]
        //[Route("api/CandyShop/Delete")]
        //public string Delete(CandyShop candy)
        //{
        //    try
        //    {

        //        string query = $"EXEC DELETE_CANDY @CandyID = {candy.CandyID}";

        //        DataTable dt = new DataTable();
        //        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CinemaApp"].ConnectionString))
        //        {
        //            using (var cmd = new SqlCommand(query, con))
        //            {
        //                using (var da = new SqlDataAdapter(cmd))
        //                {
        //                    cmd.CommandType = CommandType.Text;
        //                    da.Fill(dt);
        //                }
        //            }
        //        }

        //        return "OK";
        //    }
        //    catch (SqlException e)
        //    {
        //        return e.Message;
        //    }
        //}
    }
}