using Core.Models;
using Core.RepositoryAbstracts;
using Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.RepositoryConcrates
{
    public class ChefRepository : GenericRepository<Chef>, IChefRepository
    {
        public ChefRepository(AppDbContext context) : base(context)
        {
        }
    }
}
