using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepository(BancoContext banco) 
        {
            _bancoContext = banco;
        }
        public Contatos create(Contatos contatos)
        {
            _bancoContext.Contatos.Add(contatos);
            _bancoContext.SaveChanges();
            return contatos;
        }
    }
}
