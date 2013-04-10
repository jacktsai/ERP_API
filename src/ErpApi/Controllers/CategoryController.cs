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
        private readonly ICategoryService _subCategoryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryController" /> class.
        /// </summary>
        public CategoryController()
        {
            this._subCategoryService = ServiceFactory.GetSubCategoryService();
        }

        /// <summary>
        /// 取得子站相關資訊。
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public GetCategoriesResponse GetCategories([FromBody]GetCategoriesRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 取得子站維護人員資訊。
        /// </summary>
        /// <param name="request">Request 內容。</param>
        /// <returns>Response 內容。</returns>
        [HttpPost]
        public GetCategoryContactsResponse GetCategoryContacts([FromBody]GetCategoryContactsRequest request)
        {
            var subCatUsers = this._subCategoryService.GetCategoryContacts(request.CategoryIds);
            var subCatContacts = subCatUsers.Select(o => this.CreateContact(o)).ToArray();

            var response = new GetCategoryContactsResponse
            {
                CategoryContacts = subCatContacts,
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