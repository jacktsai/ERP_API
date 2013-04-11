using System.Linq;
using System.Web.Http;
using ErpApi.Entities;
using ErpApi.BLL;
using ErpApi.Utilities;
using System;

namespace ErpApi.ApiControllers
{
    /// <summary>
    /// 子站相關服務。
    /// </summary>
    public class CategoryController : ApiController
    {
        /// <summary>
        /// The instance of <see cref="ErpApi.BLL.ICategoryService"/> interface.
        /// </summary>
        private readonly ICategoryService _categoryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryController" /> class.
        /// </summary>
        public CategoryController()
        {
            this._categoryService = ServiceFactory.GetSubCategoryService();
        }

        /// <summary>
        /// 取得子站相關資訊。
        /// </summary>
        /// <param name="request">Request 內容。</param>
        /// <returns>Response 內容。</returns>
        [HttpPost]
        public GetCategoriesResponse GetCategories([FromBody]GetCategoriesRequest request)
        {
            var models = this._categoryService.GetCategories(request.CategoryIds);

            var types = models
                .GroupBy(
                    model => new
                    {
                        model.CatZone.TypeId,
                        model.CatZone.TypeName,
                    }
                ).Select(
                    g1 => new CategoryType
                    {
                        Id = g1.Key.TypeId,
                        Name = g1.Key.TypeName,
                        Zones = models
                            .Where(model => model.CatZone.TypeId == g1.Key.TypeId)
                            .GroupBy(model2 => new { model2.CatZone.Id, model2.CatZone.Name, })
                            .Select(
                                g2 => new CategoryZone
                                {
                                    Id = g2.Key.Id,
                                    Name = g2.Key.Name,
                                    Categories = models
                                        .Where(model => model.CatZone.TypeId == g1.Key.TypeId && model.CatZone.Id == g2.Key.Id)
                                        .Select(
                                            model => new Category
                                            {
                                                Id = model.CatSub.Id,
                                                Name = model.CatSub.Name,
                                            }
                                        ).ToArray()
                                }
                            ).ToArray()
                    }
                ).ToArray();

            return new GetCategoriesResponse
            {
                CategoryTypes = types,
            };
        }

        /// <summary>
        /// 取得子站維護人員資訊。
        /// </summary>
        /// <param name="request">Request 內容。</param>
        /// <returns>Response 內容。</returns>
        [HttpPost]
        public GetCategoryContactsResponse GetCategoryContacts([FromBody]GetCategoryContactsRequest request)
        {
            var models = this._categoryService.GetCategoryContacts(request.CategoryIds);
            var contacts = models.Select(o => this.CreateContact(o)).ToArray();

            var response = new GetCategoryContactsResponse
            {
                CategoryContacts = contacts,
            };

            return response;
        }

        /// <summary>
        /// Creates the contact.
        /// </summary>
        /// <param name="model">The sub category user.</param>
        /// <returns>The sub category contact.</returns>
        private CategoryContact CreateContact(CategoryContactModel model)
        {
            var contact = new CategoryContact
            {
                CategoryId = model.Id
            };

            if (model.Pm != null)
            {
                contact.PmBackyardId = model.Pm.BackyardId;
                contact.PmFullName = model.Pm.FullName;
                contact.PmExtNumber = model.Pm.ExtNo;
                contact.PmEmail = model.Pm.Email;
            }

            if (model.Manager != null)
            {
                contact.MgrBackyardId = model.Manager.BackyardId;
                contact.MgrFullName = model.Manager.FullName;
                contact.MgrExtNumber = model.Manager.ExtNo;
                contact.MgrEmail = model.Manager.Email;
            }

            if (model.Purchaser != null)
            {
                contact.PhrBackyardId = model.Purchaser.BackyardId;
                contact.PhrFullName = model.Purchaser.FullName;
                contact.PhrExtNumber = model.Purchaser.ExtNo;
                contact.PhrEmail = model.Purchaser.Email;
            }

            if (model.Staff != null)
            {
                contact.StaffBackyardId = model.Staff.BackyardId;
                contact.StaffFullName = model.Staff.FullName;
                contact.StaffExtNumber = model.Staff.ExtNo;
                contact.StaffEmail = model.Staff.Email;
            }

            return contact;
        }
    }
}