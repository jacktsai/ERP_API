/***
DECLARE
    @backyardId NVARCHAR(50)
SELECT
    @backyardId = 'jacktsai'
***/
SELECT
	[priuser_id],
	[priuser_name],
	[priuser_fullname],
	[priuser_department],
	[priuser_degree],
    [priuser_email],
	[priuser_homepage],
	[priuser_extno],
	[priuser_backyardid]
FROM
	[dbo].[priuser](NOLOCK)
WHERE
	[priuser_backyardid] = @backyardId