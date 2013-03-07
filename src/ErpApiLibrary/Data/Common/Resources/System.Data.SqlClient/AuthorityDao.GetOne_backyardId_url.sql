/***
DECLARE
    @backyardId NVARCHAR(50),
    @url NVARCHAR(256)
SELECT
    @backyardId = 'jacktsai',
    @url = '/test.aspx'
***/
SELECT
	CONVERT(BIT, ISNULL(MAX(CONVERT(INT, ISNULL(roles_select, 0))), 0)), -- 將多筆合併成乙筆。
	CONVERT(BIT, ISNULL(MAX(CONVERT(INT, ISNULL(roles_insert, 0))), 0)),
	CONVERT(BIT, ISNULL(MAX(CONVERT(INT, ISNULL(roles_update, 0))), 0)),
	CONVERT(BIT, ISNULL(MAX(CONVERT(INT, ISNULL(roles_delete, 0))), 0)),
	CONVERT(BIT, ISNULL(MAX(CONVERT(INT, ISNULL(roles_particular, 0))), 0)),
	CONVERT(BIT, ISNULL(MAX(CONVERT(INT, ISNULL(denyprivs_select, 0))), 0)),
	CONVERT(BIT, ISNULL(MAX(CONVERT(INT, ISNULL(denyprivs_insert, 0))), 0)),
	CONVERT(BIT, ISNULL(MAX(CONVERT(INT, ISNULL(denyprivs_update, 0))), 0)),
	CONVERT(BIT, ISNULL(MAX(CONVERT(INT, ISNULL(denyprivs_delete, 0))), 0)),
	CONVERT(BIT, ISNULL(MAX(CONVERT(INT, ISNULL(denyprivs_particular, 0))), 0))
FROM
	dbo.priuser(NOLOCK)
	JOIN dbo.privilege(NOLOCK) ON privilege_priuserid = priuser_id
	JOIN dbo.prifunc(NOLOCK) ON prifunc_id = privilege_prifuncid
	LEFT JOIN dbo.middleur(NOLOCK) ON middleur_priuserid = privilege_priuserid
	JOIN dbo.roles(NOLOCK) ON roles_id = middleur_rolesid
	LEFT JOIN dbo.privs(NOLOCK) ON privs_rolesid = roles_id AND privs_url = prifunc_url
	LEFT JOIN dbo.denyprivs(NOLOCK) ON denyprivs_priuserid = privilege_priuserid AND denyprivs_url = prifunc_url
WHERE
	priuser_backyardid = @backyardId
	AND prifunc_url = @url