using Microsoft.EntityFrameworkCore;
using ShoppingBase.Base;
using ShoppingCartEF2.Data;
using ShoppingCartEF2.Entities;
using ShoppingCartEF6.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF5.Repositories
{
    public class LibraryRepository : Repository<Library>, ILibraryRepository
    {

        public LibraryRepository(ShoppingCartDS context) : base(context) 
        {
        }

        private ShoppingCartDS DbContext
        {
            get { return DbContext as ShoppingCartDS; }
        }

        public IEnumerable<Library> Find(string libraryName)
        {
            var libraries = base.Find(w => w.LibraryName.Contains(libraryName));
            //return customers.ToList();
            //return customers.AsEnumerable();
            return libraries;

        }
        public IEnumerable<Library> FindIncludeBooks1(string libraryName)
        {
            var libraries = DbContext.Libaries
                .Include("PrimaryBooks")
                .Where(w => w.LibraryName.Contains(libraryName));
            //return customers.ToList();
            //return customers.AsEnumerable();
            return libraries;

        }
        public IEnumerable<Library> FindIncludeBooks2(string libraryName)
        {
            var libraries = DbContext.Libaries
                .Include(i => i.PrimaryBooks)
                .Where(w => w.LibraryName.Contains(libraryName));
            //return customers.ToList();
            //return customers.AsEnumerable();
            return libraries;

        }
        public IEnumerable<Library> FindIncludeBooks3(string libraryName)
        {
            var libraries = DbContext.Libaries
                .Include(i => i.PrimaryBooks)
                .ThenInclude(i => i.OnLoanLibrary)
                .Where(w => w.LibraryName.Contains(libraryName));
            //return customers.ToList();
            //return customers.AsEnumerable();
            return libraries;

        }

    }
}
