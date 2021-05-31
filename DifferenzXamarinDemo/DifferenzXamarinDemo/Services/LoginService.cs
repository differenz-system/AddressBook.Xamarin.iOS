using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DifferenzXamarinDemo.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using DifferenzXamarinDemo.LanguageResources;
using System.Net.Http;

namespace DifferenzXamarinDemo.Services
{
    public class LoginService
    {
        #region Constructor
        public LoginService()
        {
        }
        #endregion

        #region Public Properties
        public const string ServiceUrl = "https://postman-echo.com";
        #endregion

        #region Public Method
        public static async Task<LoginModel> Login(LoginModel LoginData1)
        {
            LoginModel UDI = new LoginModel();
            try
            {
                var iosClientHandler = new NSUrlSessionHandler();
                HttpClient client = new HttpClient(iosClientHandler);

                //client = new HttpClient();

                LoginObject Loginobj = new LoginObject();
                Loginobj.LoginData = LoginData1;

                client.BaseAddress = new Uri(ServiceUrl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var jData = JsonConvert.SerializeObject(Loginobj);
                var content1 = new StringContent(jData, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("/post", content1);

                var result = response.Content.ReadAsStringAsync().Result;

                var resultobject = JsonConvert.DeserializeObject<LoginResponse>(result);

                UDI = resultobject?.Data?.LoginData;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                UDI.Errors.Add(AppResources.MESSAGE_ERROR_SOMETHING_WENT_WRONG_WITH_USER_LOGIN);
            }
            return UDI;
        }
        #endregion
    }
}
