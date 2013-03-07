/*
DECLARE
	@userId INT,
	@url NVARCHAR(256)
SELECT
	@userId = 2733,
	@url = '/Security/Privilege/UserMgmt.aspx'
*/
SELECT
	roles_id,
	roles_name,
	roles_note,
	roles_select,
	roles_insert,
	roles_update,
	roles_delete,
	roles_particular
FROM
	dbo.middleur(NOLOCK)
	JOIN dbo.roles(NOLOCK) ON roles_id = middleur_rolesid
	JOIN dbo.privs(NOLOCK) ON privs_rolesid = roles_id
WHERE
	middleur_priuserid = @userId
	AND privs_url = @url