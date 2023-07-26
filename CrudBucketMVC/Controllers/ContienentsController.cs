using CrudBucketMVC.DataAccess;
using CrudBucketMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudBucketMVC.Controllers
{
    public class ContienentsController : Controller
    {
        private readonly CrudBucketContext _context;

        public ContienentsController(CrudBucketContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var contienents = _context.Contienents;
            return View(contienents);
        }


        public IActionResult New()
        {
            return View();
        }

        [HttpPost] //CREATE
        public IActionResult Index(Contienent contienent)
        {
            _context.Contienents.Add(contienent);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        [Route("/contienents/{id:int}")]
        public IActionResult Show(int id)
        {
            var contienent = _context.Contienents.Find(id);
            return View(contienent);
        }


        [Route("/contienents/{id:int}/edit")]
        public IActionResult Edit(int id)
        {
            var contienent = _context.Contienents.Find(id);
            return View(contienent);
        }

        [HttpPost]
        [Route("/contienents")]
        public IActionResult Update(Contienent contienent, int id)
        {
            contienent.Id = id;
            _context.Contienents.Update(contienent);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
