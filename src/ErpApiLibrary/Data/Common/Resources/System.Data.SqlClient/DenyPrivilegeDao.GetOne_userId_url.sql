/*
DECLARE
	@userId INT,
	@url NVARCHAR(256)
SELECT
	@userId = 2733,
	@url = '/Security/Privilege/UserMgmt.aspx'
*/
SELECT
	denyprivs_id,
	denyprivs_priuserid,
	denyprivs_url,
	denyprivs_select,
	denyprivs_insert,
	denyprivs_update,
	denyprivs_delete,
	denyprivs_particular
FROM
	dbo.denyprivs(NOLOCK)
WHERE
	denyprivs_priuserid = @userId
	AND denyprivs_url = @url