using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFrameworkCore
{
    public class EfWorkerDal : EfEntityRepositoryBase<Worker>, IWorkerDal
    {
    }
}
