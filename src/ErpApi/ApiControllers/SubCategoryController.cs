using System.Linq;
using System.Web.Http;
using ErpApi.Entities;
using ErpApi.Services;

namespace ErpApi.ApiControllers
{
    /// <summary>
    /// 子站相關服務。
    /// </summary>
    public class SubCategoryController : ApiController
    {
        /// <summary>
        /// The instance of <see cref="IServiceAdapter"/> interface.
        /// </summary>
        private readonly IServiceAdapter _adapter;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubCategoryController" /> class.
        /// </summary>
        public SubCategoryController()
        {
            this._adapter = new ServiceAdapter();
        }

        /// <summary>
        /// 取得子站維護人員資訊。
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response.</returns>
        [HttpPost]
        public GetSubCategoryContactsResponse GetContacts([FromBody]GetSubCategoryContactsRequest request)
        {
            var service = this._adapter.GetSubCategoryService();
            var subCatUsers = service.GetSubCategoryUsers(request.SubCategoryIds);
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
        /// <param name="subCategoryUser">The sub category user.</param>
        /// <returns>The sub category contact.</returns>
        private SubCategoryContact CreateContact(SubCategoryUser subCategoryUser)
        {
            var contact = new SubCategoryContact
            {
                SubCategoryId = subCategoryUser.Id
            };

            if (subCategoryUser.Pm != null)
            {
                contact.PmBackyardId = subCategoryUser.Pm.BackyardId;
                contact.PmFullName = subCategoryUser.Pm.FullName;
                contact.PmExtNumber = subCategoryUser.Pm.ExtNumber;
                contact.PmEmail = subCategoryUser.Pm.Email;
            }

            if (subCategoryUser.Manager != null)
            {
                contact.MgrBackyardId = subCategoryUser.Manager.BackyardId;
                contact.MgrFullName = subCategoryUser.Manager.FullName;
                contact.MgrExtNumber = subCategoryUser.Manager.ExtNumber;
                contact.MgrEmail = subCategoryUser.Manager.Email;
            }

            if (subCategoryUser.Purchaser != null)
            {
                contact.PhrBackyardId = subCategoryUser.Purchaser.BackyardId;
                contact.PhrFullName = subCategoryUser.Purchaser.FullName;
                contact.PhrExtNumber = subCategoryUser.Purchaser.ExtNumber;
                contact.PhrEmail = subCategoryUser.Purchaser.Email;
            }

            if (subCategoryUser.Staff != null)
            {
                contact.StaffBackyardId = subCategoryUser.Staff.BackyardId;
                contact.StaffFullName = subCategoryUser.Staff.FullName;
                contact.StaffExtNumber = subCategoryUser.Staff.ExtNumber;
                contact.StaffEmail = subCategoryUser.Staff.Email;
            }

            return contact;
        }
    }
}