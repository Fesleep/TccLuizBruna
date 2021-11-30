using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.DataAccess.Data;
using TCC.DataAccess.Repository.IRepository;
using TCC.Models;

namespace TCC.DataAccess.Repository
{
    public class FornecedorRepository : RepositoryAsync<Fornecedor>, IFornecedorRepository
    {
        private readonly ApplicationDbContext _db;

        public FornecedorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Fornecedor fornecedor)
        {
            var objFromDb = _db.Fornecedores.FirstOrDefault(s => s.Id == fornecedor.Id);
            if (objFromDb != null)
            {
                objFromDb.Nome = fornecedor.Nome;
                objFromDb.NumeroTelefone = fornecedor.NumeroTelefone;
                objFromDb.Cep = fornecedor.Cep;
                objFromDb.Uf = fornecedor.Uf;
                objFromDb.Cidade = fornecedor.Cidade;
                objFromDb.Bairro = fornecedor.Bairro;
                objFromDb.Rua = fornecedor.Rua;
                objFromDb.Numero = fornecedor.Numero;
                objFromDb.DataAtualizacao = DateTime.Now;
                objFromDb.Deletado = false;
            }
        }
    }
}
