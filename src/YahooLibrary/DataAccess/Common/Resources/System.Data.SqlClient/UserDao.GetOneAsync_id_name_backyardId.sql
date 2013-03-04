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
    (@id IS NULL OR [priuser_id] = @id)
    AND (@name IS NULL OR [priuser_name] = @name)
	AND (@backyardId IS NULL OR [priuser_backyardid] = @backyardId)