using System;
using System.IO;
using System.Reflection;
using System.Resources;

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

            var daoType = dao.GetType();

            this._baseNamespace = string.Format("{0}.Resources.{1}.{2}", daoType.Namespace, dao.Settings.ProviderName, daoType.Name);
        }

        /// <summary>
        /// 以字串型式讀取內嵌資源。
        /// </summary>
        /// <param name="resourceName">Name of the resource.</param>
        /// <returns>資源內容。</returns>
        /// <exception cref="System.ArgumentNullException">resourceName</exception>
        /// <exception cref="System.Resources.MissingManifestResourceException">如果無指定的資源名稱。</exception>
        public string GetString(string resourceName)
        {
            if (resourceName == null)
            {
                throw new ArgumentNullException("resourceName");
            }

            var assembly = Assembly.GetCallingAssembly();
            string name = string.Format("{0}.{1}", this._baseNamespace, resourceName);
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