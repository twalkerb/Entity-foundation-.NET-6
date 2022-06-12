using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBase.Interfaces
{
    public interface IUnitOfWork
    {
        DbContext Context { get; }

        Task<int> CommitAsync();
        int Commit();
    }
}
