/***
DECLARE
    @userId INT
SELECT
    @userId = 2733
***/
SELECT
	catsub_id
FROM
	dbo.catprivilege(NOLOCK)
	JOIN dbo.catsub(NOLOCK) ON catsub_id = catprivilege_catsubid
WHERE
	catprivilege_priuserid = @userId