using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _20GRPED.MVC.A10.MvcAdoNet.Models;

namespace _20GRPED.MVC.A10.MvcAdoNet.Repositories
{
    public class PessoaInMemoryRepository : IPessoaRepository
    {
        private static readonly List<PessoaModel> _pessoas
            = new List<PessoaModel>
            {
                new PessoaModel
                {
                    Id = 1,
                    Nome = "PessoaTeste",
                    Nascimento = new DateTime(2001, 12, 31)
                }
            };

        public IEnumerable<PessoaModel> GetAll()
        {
            return _pessoas;
        }

        public void Add(PessoaModel newPessoaModel)
        {
            _pessoas.Add(newPessoaModel);
        }
    }
}
