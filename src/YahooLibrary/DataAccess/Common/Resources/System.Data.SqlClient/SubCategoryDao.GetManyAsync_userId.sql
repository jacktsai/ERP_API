SELECT
	catsub_id,
	catsub_name,
	catsub_catzoneid,
    catsubusr_usrname,
    catsub_mdypm,
    catsub_mdypurher,
    catsub_mdystaff
FROM
	dbo.catprivilege(NOLOCK)
	JOIN dbo.catsub(NOLOCK) ON catsub_id = catprivilege_catsubid
	LEFT JOIN dbo.catsubusr WITH (NOLOCK) ON catsubusr_catsubid = catsub_id
WHERE
	catprivilege_priuserid = @userId