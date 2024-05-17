using Business.Exceptions;
using Business.Services.Abstracts;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace RestoranNaz.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChefsController : Controller
    {
        IChefService _chefService;

        public ChefsController(IChefService chefService)
        {
            _chefService = chefService;
        }

        public IActionResult Index()
        {
            var chefs= _chefService.GetAllChef();

            return View(chefs);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Chef chef)
        {
            if(!ModelState.IsValid) return NotFound();
            try
            {
                _chefService.AddChef(chef);
            }
            catch(ImageContextExceptions ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (ImageLengthException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch(EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var chef=_chefService.GetChef(x=>x.Id==id);
            if(chef==null) return NotFound("Chef tapilmadi");
            return View(chef);
        }
        [HttpPost]
        public IActionResult Update(Chef chef)
        {
            if (!ModelState.IsValid) return View();
            
            try
            {
                _chefService.UpdateChef(chef.Id, chef);
            }
            catch (Business.Exceptions.FileNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ImageContextExceptions ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (ImageLengthException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete (int id)
        {
            var chef = _chefService.GetChef(x => x.Id == id);
            if (chef == null) return NotFound("Chef tapilmadi");
            return View(chef);
        }
        [HttpPost]
        public IActionResult DeletePost(int id)
        {
           
            if (!ModelState.IsValid) return NotFound();
            try
            {
                _chefService.DeleteChef(id);
            }
            catch(Business.Exceptions.FileNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            return RedirectToAction("Index");
        }
    }
}
