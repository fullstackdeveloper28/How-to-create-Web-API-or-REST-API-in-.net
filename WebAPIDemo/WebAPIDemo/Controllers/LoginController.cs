using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace WebAPIDemo.Controllers
{
    public class LoginController : ApiController
    {
        [Route("Angular/api/Login")]
        [HttpPost]
        public HttpResponseMessage Login(Login login)
        {
            DataTable ldt = new DataTable();
            List<Login> loginList = new List<Login>();

            bool isSuccess = true;
            HttpResponseMessage response = null;
            try
            {
                ldt = DB.LoginDetails(login);
                if (ldt.Rows.Count > 0)
                {

                    for (int i = 0; i < ldt.Rows.Count; i++)
                    {
                        Login login1 = new Login();
                        login1.LoginName = ldt.Rows[i]["LOGIN_NAME"].ToString();
                        login1.Password = ldt.Rows[i]["PASSWORD"].ToString();
                        login1.Mobile = ldt.Rows[i]["MOBILE"].ToString();
                        loginList.Add(login1);
                    }
                }
                else
                {

                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                isSuccess = false;

            }
            if (isSuccess)
            {
                string InputData = new JavaScriptSerializer().Serialize(loginList);

                response = new HttpResponseMessage()
                {

                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(InputData, Encoding.UTF8, "application/json")

                };
            }
            else
            {
                response = new HttpResponseMessage()
                {

                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent("", Encoding.UTF8, "application/json")
                };
            }
            return response;
        }
    }
}
public class Login
{
    public String LoginName { get; set; }
    public string Password { get; set; }
    public string Mobile { get; set; }
}
public class DB
{
    public static string myconstring = ConfigurationManager.ConnectionStrings["AngularDB"].ConnectionString;
    public static DataTable LoginDetails(Login login)
    {
        DataTable ldt = new DataTable();
        try
        {
            using (SqlConnection con = new SqlConnection(myconstring))
            {
                SqlDataAdapter adapter1 = new SqlDataAdapter("GetLoginDetails", con);
                adapter1.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter1.SelectCommand.Parameters.AddWithValue("@loginName", login.LoginName);
                adapter1.SelectCommand.Parameters.AddWithValue("@password", login.Password);

                adapter1.Fill(ldt);

            }
        }
        catch (Exception ex)
        {
            return null;
        }
        return ldt;
    }
}
