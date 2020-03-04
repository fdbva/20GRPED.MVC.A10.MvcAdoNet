using _20GRPED.MVC.A10.MvcAdoNet.Models;
using _20GRPED.MVC.A10.MvcAdoNet.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace _20GRPED.MVC.A10.MvcAdoNet.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaController(
            IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public IActionResult Index()
        {
            var pessoas = _pessoaRepository.GetAll();
            return View(pessoas);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PessoaModel newPessoaModel)
        {
            try
            {
                // TODO: Add insert logic here
                _pessoaRepository.Add(newPessoaModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}