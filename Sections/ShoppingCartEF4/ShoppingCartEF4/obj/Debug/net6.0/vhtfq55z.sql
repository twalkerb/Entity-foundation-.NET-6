BEGIN TRANSACTION;
GO

ALTER TABLE [Orders] ADD [PackageType] nvarchar(max) NULL;
GO

ALTER TABLE [Orders] ADD [PackageSequence] nvarchar(max) NULL;
GO


    UPDATE Orders
    SET PackageType=SUBSTRING(PackageSerial, 1, 4);

GO


    UPDATE Orders
    SET PackageSequence= SUBSTRING(PackageSerial, 5, LEN(PackageSerial) );

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'PackageSerial');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Orders] DROP COLUMN [PackageSerial];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220313201814_splitPackageSerial', N'6.0.3');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO


    EXEC ('CREATE PROCEDURE getFullName
        @LastName nvarchar(50),
        @FirstName nvarchar(50)
    AS
        RETURN @LastName + @FirstName;')
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220313202229_spGetFullName', N'6.0.3');
GO

COMMIT;
GO

