using Cadastro.Application.DTOs;
using Cadastro.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class LogradouroController : ControllerBase
    {
        public readonly IClienteService _clienteService;
        public readonly ILogradouroService _logradouroService;

        public LogradouroController(ILogradouroService logradouroService,
            IClienteService clienteService)
        {
            _logradouroService = logradouroService;
            _clienteService = clienteService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LogradouroDTO>> Get(int id)
        {
            var logradouro = await _logradouroService.GetLogradouroByCliente(id);
            if (logradouro == null)
            {
                return NotFound();
            }

            return Ok(logradouro);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] LogradouroDTO logradouroDTO)
        {
            var ClienteExiste = await _clienteService.GetById(logradouroDTO.ClienteId);
            if (ClienteExiste == null)
            {
                return NotFound();
            }

            await _logradouroService.CreateLogradouro(logradouroDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var logradouroExiste = await _logradouroService.GetLogradouro(id);
            if (logradouroExiste == null)
            {
                return NotFound();
            }
            await _logradouroService.DeleteLogradouro(id);
            return Ok(logradouroExiste);
        }
    }
}
