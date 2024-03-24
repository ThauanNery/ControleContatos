using ControleDeContatos.Models;

namespace ControleDeContatos.Repository
{
    public interface IContatoRepository
    {
        Contatos GetId(int id);
        List<Contatos> GetAll();
        Contatos create( Contatos contatos );
        Contatos update( Contatos contatos );
        bool delete( int id );
    }
}
