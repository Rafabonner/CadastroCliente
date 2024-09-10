using CadastroCliente.Domain;
using CadastroCliente.Dto;
using CadastroCliente.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCliente.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _clienteRepository.GetAsync(id);
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _clienteRepository.GetAllAsync();
            return result?.Count > 0 ? Ok(result) : BadRequest();
        }
        [HttpPost()]
        public async Task<IActionResult> PostAsync(ClienteRequest clienteRequest)
        {
            Cliente cliente = new Cliente() { Nome = clienteRequest.Nome, CPF = clienteRequest.CPF, Endereco = clienteRequest.Endereco, EstadoCivil = clienteRequest.EstadoCivil, Genero = clienteRequest.Genero };
            var result = await _clienteRepository.CreateAsycn(cliente);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _clienteRepository.DeleteAsync(id);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, ClienteRequest clienteRequest)
        {
            Cliente cliente = new Cliente() {Id = id, Nome = clienteRequest.Nome, CPF = clienteRequest.CPF, Endereco = clienteRequest.Endereco, EstadoCivil = clienteRequest.EstadoCivil, Genero = clienteRequest.Genero };
            var result = await _clienteRepository.UpdateAsync(cliente);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }



    }
}
