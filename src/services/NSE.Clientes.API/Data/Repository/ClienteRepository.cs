using NSE.Clientes.API.Models;
using NSE.Clientes.API.Models.Interface;
using NSE.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NSE.Clientes.API.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClientesContext _clientesContext;
        public IUnitOfWork UnitOfWork => _clientesContext;

        public ClienteRepository(ClientesContext clientesContext)
        {
            _clientesContext = clientesContext;
        }

        public void Add(Cliente cliente)
        {
            _clientesContext.Add(cliente);
        }

        public void Dispose()
        {
            _clientesContext.Dispose();
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _clientesContext.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetByCpf(string cpf)
        {
            return await _clientesContext.Clientes.FirstOrDefaultAsync(c => c.Cpf.Numero == cpf);
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            _clientesContext.Enderecos.Add(endereco);
        }

        public async Task<Endereco> ObterEnderecoPorId(Guid id)
        {
            return await _clientesContext.Enderecos.FirstOrDefaultAsync(e => e.ClienteId == id);
        }
    }
}
