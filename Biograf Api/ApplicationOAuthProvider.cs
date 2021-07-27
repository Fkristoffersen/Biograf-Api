using Biograf_Api.Models;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Biograf_Api
{



    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public bool AllowInsecureHttp { get; internal set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public string values(Customer customer)
        {

            return customer.Email;

        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();


        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CinemaApp"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand sql_cmnd = new SqlCommand("LOGIN_CUSTOMER", con);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = context.UserName;
                    sql_cmnd.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = context.Password;
                    using (SqlDataReader dataReader = sql_cmnd.ExecuteReader())
                    {
                        if(dataReader.HasRows)
                        {
                            Email = context.UserName;
                            Password = context.Password;

                        }
                        else
                        {
                            context.SetError("invalid_grant", "Provided username and password is incorrect");
                            return;
                        }

                    }

                }
                catch( Exception e)
                {
                    Email = "0";
                    Password = "0";

                }



            }


            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            if (context.UserName == Email && context.Password == Password)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "Customer"));
                identity.AddClaim(new Claim("username", "admin"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Hi Admin"));
                context.Validated(identity);
            }

            else if (context.UserName == "user" && context.Password == "user")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "Customer"));
                identity.AddClaim(new Claim("username", "user"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Hi bob"));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
                return;
            }



        }



    }

}