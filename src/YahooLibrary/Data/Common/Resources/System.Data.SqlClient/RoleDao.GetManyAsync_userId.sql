SELECT
	roles_id,
	roles_name,
	roles_select,
	roles_insert,
	roles_update,
	roles_delete,
	roles_particular
FROM
	dbo.middleur(NOLOCK)
	JOIN dbo.roles(NOLOCK) ON roles_id = middleur_rolesid
WHERE
	middleur_priuserid = @user_id