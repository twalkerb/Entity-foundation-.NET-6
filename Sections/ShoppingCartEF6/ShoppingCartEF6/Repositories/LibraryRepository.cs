using Microsoft.EntityFrameworkCore;
using ShoppingCartEF2.Data;
using ShoppingCartEF2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF5.Repositories
{
    public class LibraryRepository
    {
        ShoppingCartDS _context;

        public LibraryRepository(ShoppingCartDS context)
        {
            _context = context;
        }


        public IEnumerable<Library> Find(string libraryName)
        {
            var libraries = _context.Libaries.Where(w => w.LibraryName.Contains(libraryName));
            //return customers.ToList();
            //return customers.AsEnumerable();
            return libraries;

        }
        public IEnumerable<Library> FindIncludeBooks1(string libraryName)
        {
            var libraries = _context.Libaries
                .Include("PrimaryBooks")
                .Where(w => w.LibraryName.Contains(libraryName));
            //return customers.ToList();
            //return customers.AsEnumerable();
            return libraries;

        }
        public IEnumerable<Library> FindIncludeBooks2(string libraryName)
        {
            var libraries = _context.Libaries
                .Include(i => i.PrimaryBooks)
                .Where(w => w.LibraryName.Contains(libraryName));
            //return customers.ToList();
            //return customers.AsEnumerable();
            return libraries;

        }
        public IEnumerable<Library> FindIncludeBooks3(string libraryName)
        {
            var libraries = _context.Libaries
                .Include(i => i.PrimaryBooks)
                .ThenInclude(i => i.OnLoanLibrary)
                .Where(w => w.LibraryName.Contains(libraryName));
            //return customers.ToList();
            //return customers.AsEnumerable();
            return libraries;

        }

    }
}
