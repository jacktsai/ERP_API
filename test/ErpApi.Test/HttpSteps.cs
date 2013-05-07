using System;
using TechTalk.SpecFlow;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErpApi.Test
{
    /// <summary>
    /// 提供 HTTP 相關的 steps
    /// </summary>
    [Binding]
    public class HttpSteps
    {
        /// <summary>
        /// The instance of HttpContext.
        /// </summary>
        private readonly HttpContext _context;

        public HttpSteps(HttpContext context)
        {
            this._context = context;
        }

        [Then(@"HTTP回傳狀態為 '(.*)'")]
        public void ThenHTTP回傳狀態為(HttpStatusCode expected)
        {
            Assert.AreEqual(expected, this._context.StatusCode);
        }

        [Then(@"HTTP回傳成功狀態")]
        public void ThenHTTP回傳成功狀態()
        {
            Assert.IsTrue(this._context.IsSuccess, this._context.ErrorMessage);
        }
    }
}
