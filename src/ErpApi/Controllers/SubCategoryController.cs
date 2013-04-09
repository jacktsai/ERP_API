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
    public class SubCategoryController : ApiController
    {
        /// <summary>
        /// The instance of <see cref="ErpApi.BLL.ISubCategoryService"/> interface.
        /// </summary>
        private readonly ISubCategoryService _subCategoryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubCategoryController" /> class.
        /// </summary>
        public SubCategoryController()
        {
            this._subCategoryService = ServiceFactory.GetSubCategoryService();
        }

        /// <summary>
        /// 取得子站相關資訊。
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public GetSubCategoriesResponse GetSubCategories([FromBody]GetSubCategoriesRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 取得子站維護人員資訊。
        /// </summary>
        /// <param name="request">Request 內容。</param>
        /// <returns>Response 內容。</returns>
        [HttpPost]
        public GetSubCategoryContactsResponse GetContacts([FromBody]GetSubCategoryContactsRequest request)
        {
            var subCatUsers = this._subCategoryService.GetSubCategoryUsers(request.CatSubIds);
            var subCatContacts = subCatUsers.Select(o => this.CreateContact(o)).ToArray();

            var response = new GetSubCategoryContactsResponse
            {
                Contacts = subCatContacts,
            };

            return response;
        }

        /// <summary>
        /// Creates the contact.
        /// </summary>
        /// <param name="model">The sub category user.</param>
        /// <returns>The sub category contact.</returns>
        private SubCategoryContact CreateContact(SubCategoryContactModel model)
        {
            var contact = new SubCategoryContact
            {
                SubCategoryId = model.Id
            };

            if (model.Pm != null)
            {
                contact.PmBackyardId = model.Pm.priuser_backyardid;
                contact.PmFullName = model.Pm.priuser_fullname;
                contact.PmExtNumber = model.Pm.priuser_extno;
                contact.PmEmail = model.Pm.priuser_email;
            }

            if (model.Manager != null)
            {
                contact.MgrBackyardId = model.Manager.priuser_backyardid;
                contact.MgrFullName = model.Manager.priuser_fullname;
                contact.MgrExtNumber = model.Manager.priuser_extno;
                contact.MgrEmail = model.Manager.priuser_email;
            }

            if (model.Purchaser != null)
            {
                contact.PhrBackyardId = model.Purchaser.priuser_backyardid;
                contact.PhrFullName = model.Purchaser.priuser_fullname;
                contact.PhrExtNumber = model.Purchaser.priuser_extno;
                contact.PhrEmail = model.Purchaser.priuser_email;
            }

            if (model.Staff != null)
            {
                contact.StaffBackyardId = model.Staff.priuser_backyardid;
                contact.StaffFullName = model.Staff.priuser_fullname;
                contact.StaffExtNumber = model.Staff.priuser_extno;
                contact.StaffEmail = model.Staff.priuser_email;
            }

            return contact;
        }
    }
}