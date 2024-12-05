using InnovaStay.Data.Abstract;
using InnovaStay.Data.Concrete;
using InnovaStay.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaStay.Data.Repositories
{
    public class SubscribeRepository : GenericRepository<Subscribe>, ISubscribeRepository
    {
        public SubscribeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
