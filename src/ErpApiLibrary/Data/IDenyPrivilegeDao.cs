namespace ErpApi.Data
{
    /// <summary>
    /// 拒絕權限資料存取介面。
    /// </summary>
    public interface IDenyPrivilegeDao
    {
        /// <summary>
        /// 取得乙筆拒絕權限資料。
        /// </summary>
        /// <param name="userId">使用者序號。</param>
        /// <param name="url">URL。</param>
        /// <returns>拒絕權限資料。</returns>
        DenyPrivilegeData GetOne(int userId, string url);
    }
}