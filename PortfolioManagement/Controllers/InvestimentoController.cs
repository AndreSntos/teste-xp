using Microsoft.AspNetCore.Mvc;
using PortfolioManagement.Models;
using PortfolioManagement.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestimentoController : ControllerBase
    {
        private readonly IInvestimentoService _service;

        public InvestimentoController(IInvestimentoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Investimento>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Investimento>> GetById(int id)
        {
            var investimento = await _service.GetByIdAsync(id);
            if (investimento == null) return NotFound();
            return Ok(investimento);
        }

        [HttpGet("cliente/{clienteId}")]
        public async Task<ActionResult<IEnumerable<Investimento>>> GetByClienteId(int clienteId)
        {
            return Ok(await _service.GetByClienteIdAsync(clienteId));
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] Investimento investimento)
        {
            await _service.AddAsync(investimento);
            return CreatedAtAction(nameof(GetById), new { id = investimento.Id }, investimento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Investimento investimento)
        {
            if (id != investimento.Id) return BadRequest();
            await _service.UpdateAsync(investimento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
