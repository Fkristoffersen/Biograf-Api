using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BiografApi.Controllers
{
    public class ShoppingCartController : ApiController
    {
        [Route("api/ShoppingCart/GetAll")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            string query = @"EXEC ALL_SHOPPINGCART";
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

        [Route("api/ShoppingCart/GetSingle")]
        [HttpGet]
        public HttpResponseMessage GetSingle(int id)
        {
            string query = $"EXEC THE_SHOPPINGCART @OrderID = {id}";
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

        [Route("api/ShoppingCart/GetCustomerID")]
        [HttpGet]
        public HttpResponseMessage GetCustomerID(int id)
        {
            string query = $"EXEC THE_SHOPPINGCARTCUSTOMER @CustomerID = {id}";
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
        [Route("api/ShoppingCart/Post")]
        public HttpResponseMessage Post(int CustomerID, int OrderID, int CandyID, int Quantity, int Date, int Total)
        {

            string query = $"EXEC NEW_SHOPPINGCART " +
                           $"@CustomerID = '{CustomerID}', @OrderID = '{OrderID}', @CandyID = '{CandyID}', @Quantity= '{Quantity}', @Date= '{Date}', @Total= '{Total}'";


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
        [Route("api/ShoppingCart/Put")]
        public HttpResponseMessage Put(int CartID, int CustomerID, int OrderID, int CandyID, int Quantity, string Date, int Total)
        {

            string query = $"EXEC UPDATE_SHOPPINGCART " +
                           $"@CartID = '{CartID}', @CustomerID = '{CustomerID}', @OrderID = '{OrderID}', @CandyID = '{CandyID}', @Quantity = '{Quantity}', @Date = '{Date}', @Total = '{Total}'";


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
        [Route("api/ShoppingCart/Delete")]
        public HttpResponseMessage Delete(int id)
        {

            string query = $"EXEC DEL_SHOPPINGCART @OrderID = {id}";

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
