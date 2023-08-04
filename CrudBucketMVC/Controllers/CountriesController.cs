using CrudBucketMVC.DataAccess;
using CrudBucketMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudBucketMVC.Controllers
{
    public class CountriesController : Controller
    {
        private readonly CrudBucketContext _context;

        public CountriesController(CrudBucketContext context)
        {
            _context = context;
        }

        [Route("/contienents/{contienentId:int}/countries")]
        public IActionResult Index(int contienentId)
        {
            var contienent = _context.Contienents.Where(c => c.Id == contienentId).Include(c => c.Countries).First();
            return View(contienent);
        }

        [Route("/contienents/{contienentId:int}/countries/new")]
        public IActionResult New(int contienentId)
        {
            var contienent = _context.Contienents
                .Where(c => c.Id == contienentId)
                .Include(c => c.Countries)
                .First();

            return View(contienent);
        }

        [HttpPost]
        [Route("/contienents/{contienentId:int}/countries")]
        public IActionResult Create(Country country, int contienentId)
        {
            var contienent = _context.Contienents
                .Where(c => c.Id == contienentId)
                .Include(c => c.Countries)
                .First();

            contienent.Countries.Add(country);
            _context.Countries.Add(country);
            _context.SaveChanges();

            return RedirectToAction("Index", new { contienentId = contienent.Id });
        }

        [Route("/contienents/{id:int}/countries/{countryId:int}/edit")]
        public IActionResult Edit(int id, int countryId)
        {
            var contienent = _context.Contienents.Find(id);
            var country = _context.Countries.Find(countryId);

            country.contienent = contienent;

            return View(country);
        }


        [HttpPost]
        [Route("/contienents/{contienentId:int}/countries/{countryid:int}")]
        public IActionResult Update(Country country, int countryid, int contienentId)
        {
            var contienent = _context.Contienents.Find(contienentId);

            country.contienent = contienent;
            country.Id = countryid;
            _context.Countries.Update(country);
            _context.SaveChanges();

            return RedirectToAction("Index", new { contienentId = contienent.Id });
        }



        [HttpPost]
        [Route("/countries/{contienentId:int}/countries/{countryid:int}/delete")]
        public IActionResult Delete(int contienentId, int countryid)
        {
            var contienent = _context.Contienents.Find(contienentId);

            var country = _context.Countries.Find(countryid);
            _context.Countries.Remove(country);
            _context.SaveChanges();

            return RedirectToAction("Index", new { contienentId = contienent.Id });

        }


    }
}
