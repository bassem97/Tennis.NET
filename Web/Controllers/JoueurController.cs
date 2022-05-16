
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Joueur;
using Service.Pays;

namespace Web.Controllers
{
    public class JoueurController : Controller
    {
        private readonly IJoueurService _joueurService;
        private readonly IPaysService _paysService;

        public JoueurController(IJoueurService joueurService,IPaysService paysService)
        {
            _joueurService = joueurService;
            _paysService = paysService;
        }

        // GET: Joueur
        public IActionResult Index()
        {
            List<Joueur> listJoueurs = _joueurService.GetMany().OrderBy(j => j.Nom).ToList();

            return View(listJoueurs);
        }
        
        [HttpPost]
        public ActionResult Index(string search)
        {
            List<Joueur> listJoueurs;
            if (!string.IsNullOrEmpty(search))
            {
                listJoueurs = _joueurService.GetMany(d => d.Nom.StartsWith(search)).OrderBy(j => j.Nom).ToList();
            }
            else
            {
                listJoueurs = _joueurService.GetMany().ToList();
            }
            return View(listJoueurs);
        }

        // GET: Joueur/Create
        public ActionResult Create()
        {
            
            List<Pays> payss = _paysService.GetMany().ToList();
            ViewBag.payss = new SelectList(payss, "CodePays", "Nom");
            return View();
        }

        // POST: Joueur/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Joueur joueur, IFormFile ImageFile)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",ImageFile.FileName);
            Stream stream = new FileStream(path, FileMode.Create);
            ImageFile.CopyTo(stream);
            joueur.Photo = ImageFile.FileName;
            _joueurService.Add(joueur);
            _joueurService.Commit();
            return RedirectToAction(nameof(Index));
        }

   
       
    }
}
