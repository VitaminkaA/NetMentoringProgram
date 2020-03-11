IF EXISTS (SELECT * FROM sys.objects WHERE object_id = object_id(N'[dbo].[Region]') AND type in(N'U'))
BEGIN
	EXEC sp_rename 'Region', 'Regions'; 
END