using NSE.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Clientes.API.Models.Interface
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        void Add(Cliente cliente);

        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente> GetByCpf(string cpf);

        void AdicionarEndereco(Endereco endereco);
        Task<Endereco> ObterEnderecoPorId(Guid id);
    }
}
