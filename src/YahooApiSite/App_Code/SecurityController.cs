using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net;
using Yahoo.Business.Security;
using System.Net.Http.Formatting;
using Yahoo.Business.Security.Cryptography;

public class SecurityController : ApiController
{
    private readonly ISecurityService securityService;

    public SecurityController()
    {
        var userDao = new Yahoo.DataAccess.Common.UserDao();
        var privilegeDao = new Yahoo.DataAccess.Common.PrivilegeDao();
        var hashProvider = new DefaultHashProvider();

        this.securityService = new DefaultSecurityService(userDao, privilegeDao, hashProvider);
    }

    public SecurityController(ISecurityService securityService)
    {
        this.securityService = securityService;
    }

    [HttpGet]
    public string Test(string test)
    {
        return test;
    }

    [HttpPost]
    public HttpResponseMessage AcquirePrivileges(HttpRequestMessage request)
    {
        var requestContent = request.Content.ReadAsAsync<JObject>().Result;
        var userIdToken = requestContent["userId"];
        if (userIdToken == null)
        {
            request.CreateResponse();
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        int userId = userIdToken.Value<int>();


        var privileges = this.securityService.GetPrivileges(userId);

        //var responseContent = new JObject();
        //responseContent["privileges"] = new JArray(privileges.ToArray());

        var responseContent = new
        {
            userId = userId,
            privileges = privileges,
        };

        var response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = new ObjectContent(responseContent.GetType(), responseContent, new JsonMediaTypeFormatter());

        return response;
    }
}