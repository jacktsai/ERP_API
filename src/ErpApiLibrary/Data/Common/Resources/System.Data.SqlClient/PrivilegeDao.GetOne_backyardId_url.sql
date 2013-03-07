/*
DECLARE
	@backyardId NVARCHAR(50),
	@url NVARCHAR(256)
SELECT
	@backyardId = 'jacktsai',
	@url = '/test.aspx'
*/
SELECT
	privilege_id,
	privilege_priuserid,
    privilege_prifuncid,
	privilege_note
FROM
	dbo.priuser(NOLOCK)
	JOIN dbo.privilege(NOLOCK) ON privilege_priuserid = priuser_id
	JOIN dbo.prifunc(NOLOCK) ON prifunc_id = privilege_prifuncid
WHERE
	priuser_backyardid = @backyardId
	AND prifunc_url = @url