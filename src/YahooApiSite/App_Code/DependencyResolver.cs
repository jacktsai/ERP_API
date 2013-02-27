using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Yahoo.Business.Security;
using Yahoo.DataAccess;
using Yahoo.Business.Security.Cryptography;

/// <summary>
/// DependencyResolver 的摘要描述
/// </summary>
public class DependencyResolver : IDependencyResolver
{
    IDependencyScope IDependencyResolver.BeginScope()
    {
        return this;
    }

    object IDependencyScope.GetService(Type serviceType)
    {
        return null;
    }

    IEnumerable<object> IDependencyScope.GetServices(Type serviceType)
    {
        return new object[0];
    }

    void IDisposable.Dispose()
    {
    }
}