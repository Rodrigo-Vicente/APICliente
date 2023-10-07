using Cadastro.Application.DTOs;
using Cadastro.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class ClienteController : ControllerBase
    {
        public readonly IClienteService _clienteService;
        public readonly ILogradouroService _logradouroService;

        public ClienteController(IClienteService clienteService,
            ILogradouroService logradouroService)
        {
            _clienteService = clienteService;
            _logradouroService = logradouroService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get()
        {
            try
            {
                var cliente = await _clienteService.GetAll();
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetCliente")]
        public async Task<ActionResult<ClienteDTO>> Get(int id)
        {
            var cliente = await _clienteService.GetById(id);

            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteDTO clienteDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _clienteService.CreateCliente(clienteDTO);

            return new CreatedAtRouteResult("GetCliente",
                    new { id = clienteDTO.ID }, clienteDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClienteDTO clienteDTO)
        {
            if (id != clienteDTO.ID)
            {
                return BadRequest();
            }
            await _clienteService.UpdateCliente(clienteDTO);
            return Ok(clienteDTO);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var clienteExite = await _clienteService.GetById(id);
            if (clienteExite == null)
            {
                return NotFound();
            }
            await _clienteService.DeleteCliente(id);
            return Ok(clienteExite);
        }
    }
}
