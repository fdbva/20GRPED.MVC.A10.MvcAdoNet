using _20GRPED.MVC.A10.MvcAdoNet.Models;
using System.Collections.Generic;

namespace _20GRPED.MVC.A10.MvcAdoNet.Repositories
{
    public interface IPessoaRepository
    {
        IEnumerable<PessoaModel> GetAll();
        void Add(PessoaModel newPessoaModel);
    }
}
