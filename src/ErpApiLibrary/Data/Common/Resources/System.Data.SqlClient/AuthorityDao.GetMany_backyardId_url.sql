/***
DECLARE
    @backyardId NVARCHAR(50),
    @url NVARCHAR(256)
SELECT
    @backyardId = 'jacktsai',
    @url = '/test.aspx'
***/
SELECT
    roles_select,
    roles_insert,
    roles_update,
    roles_delete,
    roles_particular,
    denyprivs_select,
    denyprivs_insert,
    denyprivs_update,
    denyprivs_delete,
    denyprivs_particular
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