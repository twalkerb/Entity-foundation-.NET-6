BEGIN TRANSACTION;
GO


    EXEC (Drop PROCEDURE getFullName)
GO

DELETE FROM [__EFMigrationsHistory]
WHERE [MigrationId] = N'20220313202229_spGetFullName';
GO

COMMIT;
GO

