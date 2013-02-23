using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Reflection;
using System.IO;

namespace Yahoo.DataAccess.Common.Resources
{
    public class Resource
    {
        static readonly Assembly assembly;

        static Resource()
        {
            assembly = Assembly.GetExecutingAssembly();
        }

        readonly string baseNamespace;

        public Resource(CommonDao dao)
        {
            if (dao == null)
            {
                throw new ArgumentNullException("dao");
            }

            baseNamespace = string.Format("{0}.{1}.{2}", typeof(Resource).Namespace, dao.Settings.ProviderName, dao.GetType().Name);
        }

        public string GetString(string resourceName)
        {
            if (resourceName == null)
            {
                throw new ArgumentNullException("resourceName");
            }

            string name = string.Format("{0}.{1}", baseNamespace, resourceName);
            
            var stream = assembly.GetManifestResourceStream(name);
            if (stream == null)
            {
                throw new MissingManifestResourceException(name);
            }

            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
