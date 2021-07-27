using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Biograf_Api.Models;

namespace Biograf_Api.Controllers
{
    public class CustomerController : ApiController
    {

        [Route("api/customer/getAll")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [AcceptVerbs("POST")]
        [System.Web.Http.HttpGet]
        [Route("api/customer/Post")]
        public HttpResponseMessage Post( string Firstname, string Lastname, string Email, string Address, int Zipcode, string Password)
        {
            ApplicationOAuthProvider value = new ApplicationOAuthProvider();
            value.Email = Email;
            value.Password = Password;

            string query = $"EXEC NEW_CUSTOMER " +
                $"@Firstname = '{Firstname}', @Lastname = '{Lastname}', @Email = '{Email}', @Address = '{Address}', @Zipcode = '{Zipcode}', @Password = '{Password}'";


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
        //http://localhost:62272/api/customer/post?Firstname=Master&Lastname=Luski&Email=doglife@gmail.com&Address=Dominos&Zipcode=2400&Password=2554

        [Authorize(Roles = "Customer")]
        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        [Route("api/customer/get")] //<------ skiftet til Read istedet for Select
        public HttpResponseMessage Select(int id)
        {
            DataTable table = new DataTable();
            var identity = (ClaimsIdentity)User.Identity;

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CinemaApp"].ConnectionString))
            {
                con.Open();
                SqlCommand sql_cmnd = new SqlCommand("SELECT_CUSTOMER", con);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@CustomerID", SqlDbType.Int).Value = id;
                SqlDataReader dataReader = sql_cmnd.ExecuteReader();
                table.Load(dataReader);

            }
            return Request.CreateResponse(HttpStatusCode.OK,table); //sender statuskode og datatable.

        }


        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        [Route("api/customer/login")] //<------ skiftet til Read istedet for Select
        public HttpResponseMessage login(string Email,string Password)
        {
            Customer value = new Customer();
            value.Email = Email;
            value.Password = Password;

            DataTable table = new DataTable();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CinemaApp"].ConnectionString))
            {
                con.Open();
                SqlCommand sql_cmnd = new SqlCommand("LOGIN_CUSTOMER", con);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = Email;
                sql_cmnd.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = Password;
                SqlDataReader dataReader = sql_cmnd.ExecuteReader();
                table.Load(dataReader);

            }
            return Request.CreateResponse(HttpStatusCode.OK, table); //sender statuskode og datatable.

        }

        [System.Web.Http.AcceptVerbs("DELETE")]
        [System.Web.Http.HttpGet]
        [Route("api/customer/delete")]
        public HttpResponseMessage Delete(int id)
        {
           

            string query =
                      $"EXEC DELETE_CUSTOMER @CustomerID = {id}";
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

        [System.Web.Http.AcceptVerbs("PUT")]
        [System.Web.Http.HttpGet]
        [Route("api/Customer/put")]
        public HttpResponseMessage Put(int id, string Firstname, string Lastname, string Email, string Address, int Zipcode, string Password)
        {
            string query = $"EXEC UPDATE_CUSTOMER" +
                $"@CustomerID = '{id}', @Firstname = '{Firstname}', @Lastname = '{Lastname}', @Email = '{Email}', @Address = '{Address}', @Zipcode = '{Zipcode}', @Password = '{Password}'";


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

            return Request.CreateResponse(HttpStatusCode.OK);
            
        }

        //[Route("api/customer/create")]
        //[System.Web.Http.AcceptVerbs("POST")]
        //[System.Web.Http.HttpGet]
        //// POST api/values
        //public HttpResponseMessage Post(string Firstname, string Lastname, string Email,string Address, int Zipcode, string Password)
        //{
        //        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CinemaApp"].ConnectionString))
        //        {
        //            con.Open();
        //            SqlCommand sql_cmnd = new SqlCommand("NEW_CUSTOMER", con);
        //            sql_cmnd.CommandType = CommandType.StoredProcedure;
        //            sql_cmnd.Parameters.AddWithValue("@Firstname", SqlDbType.NVarChar).Value = Firstname;
        //            sql_cmnd.Parameters.AddWithValue("@Lastname", SqlDbType.NVarChar).Value = Lastname;
        //            sql_cmnd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = Email;
        //            sql_cmnd.Parameters.AddWithValue("@Address", SqlDbType.NVarChar).Value = Address;
        //            sql_cmnd.Parameters.AddWithValue("@Zipcode", SqlDbType.Int).Value = Zipcode;
        //            sql_cmnd.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = Password;
        //            sql_cmnd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}

        // PUT api/values/5
        /* public void Put(int id, [FromBody] string value)
         {

             DataTable table = new DataTable();

             using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CinemaApp"].ConnectionString))
             using (var cmd = new SqlCommand(query, con))
             using (var da = new SqlDataAdapter(cmd))
             {
                 cmd.CommandType = CommandType.Text;
                 da.Fill(table);
             }}
             */

        // DELETE api/values/5
    }
}