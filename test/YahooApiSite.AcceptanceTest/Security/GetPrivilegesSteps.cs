using System;
using TechTalk.SpecFlow;
using System.Net.Http;
using System.Collections.Generic;
using Yahoo.Business.Security;
using Newtonsoft.Json.Linq;
using System.Net.Http.Formatting;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Yahoo.Security
{
    [Binding]
    public class 取得使用者權限Steps
    {
        [When(@"以使用者編號 (.*) 取得權限清單")]
        public void When以使用者編號取得權限清單(int p0)
        {
            var requestContent = new
            {
                UserId = p0
            };

            base.SendRequest(HttpMethod.Post, "api/security/AcquirePrivileges", requestContent);
        }

        [Then(@"回傳使用者編號為 (.*)")]
        public void Then回傳使用者編號為(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"回傳清單筆數為 (.*)")]
        public void Then回傳清單筆數為(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"包含功能編號 (.*)")]
        public void Then包含功能編號(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"以操作者序號 (.*) 取得登入資訊")]
        public void When以操作者序號取得登入資訊(int p0)
        {
            var requestContent = new JObject
            (
                new JProperty("UserId", p0)
            );

            SendRequest(HttpMethod.Post, URI, requestContent);
        }
    }
}
