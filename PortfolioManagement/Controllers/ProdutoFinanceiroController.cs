using Microsoft.AspNetCore.Mvc;
using PortfolioManagement.Models;
using PortfolioManagement.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoFinanceiroController : ControllerBase
    {
        private readonly IProdutoFinanceiroService _service;

        public ProdutoFinanceiroController(IProdutoFinanceiroService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoFinanceiro>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoFinanceiro>> GetById(int id)
        {
            var produto = await _service.GetByIdAsync(id);
            if (produto == null) return NotFound();
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ProdutoFinanceiro produto)
        {
            await _service.AddAsync(produto);
            return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ProdutoFinanceiro produto)
        {
            if (id != produto.Id) return BadRequest();
            await _service.UpdateAsync(produto);
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
