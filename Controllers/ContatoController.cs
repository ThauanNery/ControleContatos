using ControleDeContatos.Models;
using ControleDeContatos.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.DataClassification;

namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;   
        public ContatoController(IContatoRepository contatoRepository) 
        {
            _contatoRepository = contatoRepository;
        }

        public IActionResult Index()
        {
           var listContatos = _contatoRepository.GetAll();
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Contatos contatos)
        {
            _contatoRepository.create(contatos);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
           Contatos contato = _contatoRepository.GetId(id);
            return View(contato);
        }
        [HttpPost]
        public IActionResult update(Contatos contatos)
        {
            _contatoRepository.update(contatos);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteConfirmad(int id)
        {
            Contatos contato = _contatoRepository.GetId(id);
            return View(contato);
        }
        public IActionResult Delete(int id)
        {
            _contatoRepository.delete(id);
            return RedirectToAction("Index");
        }


    }
}
