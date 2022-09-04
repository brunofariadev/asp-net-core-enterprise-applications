using Microsoft.AspNetCore.Mvc;
using NSE.Clientes.API.Application.Commands;
using NSE.Clientes.API.Models.Interface;
using NSE.Core.Mediator;
using NSE.WebAPI.Core.Controllers;
using NSE.WebAPI.Core.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Clientes.API.Controllers
{
    public class ClienteController : MainController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMediatorHandler _mediator;
        private readonly IAspNetUser _user;

        public ClienteController(IClienteRepository clienteRepository, IMediatorHandler mediator, IAspNetUser user)
        {
            _clienteRepository = clienteRepository;
            _mediator = mediator;
            _user = user;
        }

        [HttpGet("cliente/endereco")]
        public async Task<IActionResult> ObterEndereco()
        {
            var endereco = await _clienteRepository.ObterEnderecoPorId(_user.ObterUserId());

            return endereco == null ? NotFound() : CustomResponse(endereco);
        }

        [HttpPost("cliente/endereco")]
        public async Task<IActionResult> AdicionarEndereco(AdicionarEnderecoCommand endereco)
        {
            endereco.ClienteId = _user.ObterUserId();
            return CustomResponse(await _mediator.SendCommand(endereco));
        }
    }
}
