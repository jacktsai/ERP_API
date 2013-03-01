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
    dbo.privilege(NOLOCK)
    JOIN dbo.prifunc(NOLOCK) ON prifunc_id = privilege_prifuncid
    LEFT JOIN dbo.middleur(NOLOCK) ON middleur_priuserid = privilege_priuserid
    JOIN dbo.roles(NOLOCK) ON roles_id = middleur_rolesid
    JOIN dbo.privs(NOLOCK) ON privs_rolesid = roles_id AND privs_url = prifunc_url
    LEFT JOIN dbo.denyprivs(NOLOCK) ON denyprivs_priuserid = privilege_priuserid AND denyprivs_url = prifunc_url
WHERE
    privilege_priuserid = @user_id
    AND prifunc_url = @url