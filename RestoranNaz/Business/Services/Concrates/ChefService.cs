using Business.Exceptions;
using Business.Extensions;
using Business.Services.Abstracts;
using Core.Models;
using Core.RepositoryAbstracts;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrates
{
   
    public class ChefService : IChefService
    {
        private readonly IChefRepository _chefRepository;
        private readonly IWebHostEnvironment _env;

        public ChefService(IChefRepository chefRepository, IWebHostEnvironment env)
        {
            _chefRepository = chefRepository;
            _env = env;
        }

        public void AddChef(Chef chef)
        {
            if (chef == null) throw new EntityNotFoundException("Chef Tapilmadi!");
            chef.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\chefs", chef.ImageFile);
            _chefRepository.Add(chef);
            _chefRepository.Commit();
        }

        public void DeleteChef(int id)
        {
           var existChef= _chefRepository.Get(x=>x.Id==id);
            if(existChef==null) throw new EntityNotFoundException("Chef Tapilmadia!");
            Helper.DeleteFile(_env.WebRootPath, @"uploads\chefs", existChef.ImageUrl);
            _chefRepository.Delete(existChef);
            _chefRepository.Commit();
        }

        public List<Chef> GetAllChef(Func<Chef, bool>? func = null)
        {
            return _chefRepository.GetAll(func);
        }

        public Chef GetChef(Func<Chef, bool>? func = null)
        {
            return _chefRepository.Get(func);
        }

        public void UpdateChef(int id, Chef chef)
        {
            var oldChef = _chefRepository.Get(x => x.Id == id);
            if (oldChef == null) throw new EntityNotFoundException("Chef Tapilmadi!");
            if(chef.ImageFile!=null) 
            {
                Helper.DeleteFile(_env.WebRootPath, @"uploads\chefs", oldChef.ImageUrl);
                oldChef.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\chefs", chef.ImageFile);
            }
            oldChef.FullName = chef.FullName;
            oldChef.Designation= chef.Designation;
            oldChef.FbLink= chef.FbLink;
            oldChef.XLink= chef.XLink;
            oldChef.IgLink= chef.IgLink;
            _chefRepository.Commit();

        }
    }
}
