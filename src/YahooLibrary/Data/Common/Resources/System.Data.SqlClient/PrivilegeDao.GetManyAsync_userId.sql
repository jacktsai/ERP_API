DECLARE @department_user_id INT

-- GET department's priuser_id
SELECT
	@department_user_id = priuser_id
FROM
	dbo.priuser(NOLOCK)
WHERE
	priuser_name = (
		SELECT
			priuser_department
		FROM
			dbo.priuser(NOLOCK)
		WHERE
			priuser_id = @user_id
	)

SELECT DISTINCT
	prifunc_url,
	prifunc_name
FROM
    (
        -- GET privilege BY user's id
        SELECT
	        p.privilege_prifuncid
        FROM
	        dbo.priuser(NOLOCK) u
	        JOIN dbo.privilege(NOLOCK) p ON p.privilege_priuserid = u.priuser_id
        WHERE
	        u.priuser_status = 1
	        AND u.priuser_id IN (@user_id, @department_user_id)
        UNION
        -- GET privilege BY user's group
        SELECT
	        p.privilege_prifuncid
        FROM
	        dbo.priuser(NOLOCK) u
	        JOIN dbo.priusergroup(NOLOCK) g ON g.priusergroup_priuserid = u.priuser_id
	        JOIN dbo.privilege(NOLOCK) p ON p.privilege_prigroupid = g.priusergroup_prigroupid
        WHERE
	        u.priuser_status = 1
	        AND u.priuser_id IN (@user_id, @department_user_id)
    ) x
	JOIN dbo.prifunc(NOLOCK) ON prifunc_id = privilege_prifuncid
ORDER BY
    1
