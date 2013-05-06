using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErpApi.Entities
{
    /// <summary>
    /// 子站相關資訊
    /// </summary>
    public sealed class CategoryModel
    {
        /// <summary>
        /// CatSub
        /// </summary>
        public CatSub CatSub { get; set; }

        /// <summary>
        /// Catzone
        /// </summary>
        public CatZone CatZone { get; set; }
    }
}
