using Microsoft.EntityFrameworkCore;
using ShoppingBase.Interfaces;
using ShoppingCartEF2.Data;
using ShoppingCartEF4.Repositories;
using ShoppingCartEF5.Repositories;
using ShoppingCartEF6.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF6
{
    public class ShoppingCartUnitOfWork : IUnitOfWork
    {
        ShoppingCartDS context;

        ICustomerRepository customerRepo;
        ILibraryRepository libraryRepo;

        public ShoppingCartUnitOfWork(ShoppingCartDS context)
        {
            this.context = context;
        }
        public ICustomerRepository CustomerRepository => customerRepo ??= new CustomerRepository(context);
        public ILibraryRepository LibaryRepository => libraryRepo ??= new LibraryRepository(context);

        public DbContext Context
        {
            get { return context; }
        }

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public int Commit()
        {
            return context.SaveChanges();
        }

    }
}
