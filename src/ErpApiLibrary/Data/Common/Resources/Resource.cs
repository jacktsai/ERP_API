using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Reflection;
using System.IO;

namespace ErpApi.Data.Common.Resources
{
    /// <summary>
    /// 提供 CommonDao 子類別使用的內嵌資源讀取類別。
    /// </summary>
    /// <remarks>
    /// 所要存取的內嵌資源命名空間前置詞是固定的，請參閱建構子。
    /// </remarks>
    public class Resource
    {
        /// <summary>
        /// 基礎命名空間。
        /// </summary>
        private readonly string _baseNamespace;

        /// <summary>
        /// Initializes a new instance of the <see cref="Resource" /> class.
        /// </summary>
        /// <param name="dao">The instance of CommonDao class.</param>
        /// <exception cref="System.ArgumentNullException">dao</exception>
        public Resource(CommonDao dao)
        {
            if (dao == null)
            {
                throw new ArgumentNullException("dao");
            }

            _baseNamespace = string.Format("{0}.{1}.{2}", typeof(Resource).Namespace, dao.Settings.ProviderName, dao.GetType().Name);
        }

        /// <summary>
        /// 以字串型式讀取內嵌資源。
        /// </summary>
        /// <param name="resourceName">Name of the resource.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">resourceName</exception>
        /// <exception cref="System.Resources.MissingManifestResourceException">如果無指定的資源名稱。</exception>
        public string GetString(string resourceName)
        {
            if (resourceName == null)
            {
                throw new ArgumentNullException("resourceName");
            }

            string name = string.Format("{0}.{1}", _baseNamespace, resourceName);

            var assembly = Assembly.GetCallingAssembly();
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
