namespace ErpApi.Data
{
    /// <summary>
    /// 使用者功能授權資料存取介面。
    /// </summary>
    public interface IPrivilegeDao
    {
        /// <summary>
        /// 取得乙筆。
        /// </summary>
        /// <param name="backyardId">Backyard ID。</param>
        /// <param name="url">URL。</param>
        /// <returns>使用者權限資料。</returns>
        PrivilegeData GetOne(string backyardId, string url);
    }
}