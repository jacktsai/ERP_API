/*
SUMMARY:
    依據傳入的 @priuser_id 取得相關權限資訊。
INPUT:
    @priuser_id
OUTPUT:
    ROWS
    {
        privilege.privilege_id,
	    privilege.privilege_prifuncid,
	    privilege.privilege_priuserid
    }
*/

-- 底下兩行為測試時使用。
--DECLARE @priuser_id INT
--SET @priuser_id = 2733

DECLARE
    @priuser_name NVARCHAR(50),
    @priuser_department NVARCHAR(20)

-- GET name and department BY user's id
SELECT
	@priuser_name = priuser_name,
	@priuser_department = priuser_department
FROM
	dbo.priuser WITH (NOLOCK)
WHERE
	priuser_id = @priuser_id

SELECT DISTINCT
    x.privilege_prifuncid
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
	        AND u.priuser_name IN (@priuser_name, @priuser_department)
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
	        AND u.priuser_name IN (@priuser_name, @priuser_department)
    ) x
ORDER BY
    1

/*
-- 從 ERP2 的 blAuth.cs 中取得的原 SQL。
SELECT DISTINCT
	privilege_id,
	privilege_prifuncid,
	privilege_priuserid
FROM
	dbo.privilege(NOLOCK) p
	JOIN
	(
		SELECT
			priuser_id,
			priusergroup_prigroupid,
			priuser_status
		FROM
			priuser u
			LEFT JOIN priusergroup g ON u.priuser_id = g.priusergroup_priuserid
		WHERE
			priuser_name IN (@priuser_name, @priuser_department)
	) c ON p.privilege_priuserid = c.priuser_id OR p.privilege_prigroupid = c.priusergroup_prigroupid
WHERE
	c.priuser_status = 1
*/
