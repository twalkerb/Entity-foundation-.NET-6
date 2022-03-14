using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF.Extensions
{
    public static class MigrationExtension
    {
        public static OperationBuilder<CreateUserOperation> CreateUser(
                  this MigrationBuilder migrationBuilder,
                  string name,
                  string password)
        {
            var operation = new CreateUserOperation { Name = name, Password = password };
            migrationBuilder.Operations.Add(operation);

            return new OperationBuilder<CreateUserOperation>(operation);
        }
    }
}
