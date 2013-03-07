SELECT
	catsub_id,
    catsubusr_usrname,
    catsub_mdypm,
    catsub_mdypurher,
    catsub_mdystaff
FROM
	dbo.catsub(NOLOCK)
	LEFT JOIN dbo.catsubusr WITH (NOLOCK) ON catsubusr_catsubid = catsub_id
WHERE
	catsub_id IN ({0})