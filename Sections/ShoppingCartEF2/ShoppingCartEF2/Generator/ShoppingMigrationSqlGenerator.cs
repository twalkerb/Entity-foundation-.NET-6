using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using ShoppingCartEF2.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF2.Generator
{
    public class ShoppingMigrationSqlGenerator : SqlServerMigrationsSqlGenerator
    {
        public ShoppingMigrationSqlGenerator(
            MigrationsSqlGeneratorDependencies dependencies,
            IRelationalAnnotationProvider migrationsAnnotations)
    : base(dependencies, migrationsAnnotations)
        {
        }

        protected override void Generate(
                     MigrationOperation operation,
                     IModel model,
                     MigrationCommandListBuilder builder)
        {
            
            if (operation is CreateUserOperation createUserOperation)
            {
                Generate(createUserOperation, builder);
            }
            else if (operation is DropUserOperation dropUserOperation)
            {
                Generate(dropUserOperation, builder);
            }
            else
            {
                base.Generate(operation, model, builder);
            }
        }

        private void Generate(
            CreateUserOperation operation,
            MigrationCommandListBuilder builder)
        {
            var sqlHelper = Dependencies.SqlGenerationHelper;
            var stringMapping = Dependencies.TypeMappingSource.FindMapping(typeof(string));
            if (stringMapping != null)
            builder
                .Append("CREATE USER ")
                .Append(sqlHelper.DelimitIdentifier(operation.Name))
                .Append(" WITH PASSWORD = ")
                .Append(stringMapping.GenerateSqlLiteral(operation.Password))
                .AppendLine(sqlHelper.StatementTerminator)
                .EndCommand();
            else
                builder
                    .Append("CREATE USER ")
                    .Append(sqlHelper.DelimitIdentifier(operation.Name))
                    .Append(" WITH PASSWORD = '")
                    .Append(operation.Password)
                    .Append("'")
                    .AppendLine(sqlHelper.StatementTerminator)
                    .EndCommand();

        }

        private void Generate(
           DropUserOperation operation,
           MigrationCommandListBuilder builder)
        {
            var sqlHelper = Dependencies.SqlGenerationHelper;
            var stringMapping = Dependencies.TypeMappingSource.FindMapping(typeof(string));

            builder
                .Append("Drop USER ")
                .Append(sqlHelper.DelimitIdentifier(operation.Name))
                .AppendLine(sqlHelper.StatementTerminator)
                .EndCommand();
        }
    }
}
