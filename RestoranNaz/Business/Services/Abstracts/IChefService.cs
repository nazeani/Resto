using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstracts
{
    public interface IChefService
    {
        void AddChef(Chef chef);
        void DeleteChef(int id);
        void UpdateChef(int id,Chef chef);
        Chef GetChef(Func<Chef,bool>? func=null);
        List<Chef> GetAllChef(Func<Chef, bool>? func = null);
    }
}
