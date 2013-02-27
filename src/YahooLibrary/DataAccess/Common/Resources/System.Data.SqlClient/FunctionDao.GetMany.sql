SELECT
	f.prifunc_id,
	f.prifunc_prihpcatid,
	f.prifunc_prihpcatsubid
FROM
	dbo.prifunc f
WHERE
	f.prifunc_id IN ({FunctionIds})