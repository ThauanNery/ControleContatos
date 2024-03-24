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

        public Contatos GetId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id );
        }

        public List<Contatos> GetAll()
        {
            return _bancoContext.Contatos.ToList();
        }

        public Contatos create(Contatos contatos)
        {
            _bancoContext.Contatos.Add(contatos);
            _bancoContext.SaveChanges();
            return contatos;
        }

        public Contatos update(Contatos contatos)
        {
            Contatos contatoDb = GetId(contatos.Id);

            if (contatoDb == null) throw new Exception("Houve um erro na atualização do contato!");
            
            contatoDb.Nome = contatos.Nome;
            contatoDb.Endereco = contatos.Endereco;
            contatoDb.Celular = contatos.Celular;
            contatoDb.Email = contatos.Email;

            _bancoContext.Contatos.Update(contatoDb);
            _bancoContext.SaveChanges();

            return contatoDb;
        }

        public bool delete(int id)
        {
            Contatos contatoDb = GetId(id);

            if (contatoDb == null) throw new Exception("Houve um erro ao apagar do contato!");

            _bancoContext.Contatos.Remove(contatoDb);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
