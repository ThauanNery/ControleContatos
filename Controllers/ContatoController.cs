using ControleDeContatos.Models;
using ControleDeContatos.Repository;
using Microsoft.AspNetCore.Mvc;

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
            return View(listContatos);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Contatos contatos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.create(contatos);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Erro ao cadastrar o contato!";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Edit(int id)
        {
           Contatos contato = _contatoRepository.GetId(id);
            return View(contato);
        }
        [HttpPost]
        public IActionResult update(Contatos contatos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.update(contatos);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                    return RedirectToAction("Index");
                }  

                return View("Edit", contatos);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Erro ao alterar o contato!";
                return RedirectToAction("Index");
            }
       
        }

        //public IActionResult DeleteConfirmad(int id)
        //{
        //    Contatos contato = _contatoRepository.GetId(id);
        //    return View(contato);
        //}
        public IActionResult Delete(int id)
        {

            try
            {
               
                    bool apagado = _contatoRepository.delete(id);
                    
                    if(apagado)
                    {
                        TempData["MensagemSucesso"] = "Contato excluir com sucesso!";
                    }
                    else
                    {
                        TempData["MensagemErro"] = "Erro ao excluir o contato!";
                    }
                    return RedirectToAction("Index");

            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = "Erro ao excluir o contato!";
                return RedirectToAction("Index");
            }
            
        }


    }
}
