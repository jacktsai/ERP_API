SELECT
	catzone_id,
	catzone_name,
	catsub_id,
	catsub_name
FROM
	catprivilege(NOLOCK)
	JOIN catsub(NOLOCK) ON catsub_id = catprivilege_catsubid
	JOIN catzone(NOLOCK) ON catzone_id = catsub_catzoneid
WHERE
	catprivilege_priuserid = @user_id