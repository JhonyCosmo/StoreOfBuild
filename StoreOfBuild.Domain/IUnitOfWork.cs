using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoreOfBuild.Domain
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
