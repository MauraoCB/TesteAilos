using Microsoft.AspNetCore.Mvc;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Questao5.Infrastructure.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaldoController : ControllerBase
    {

        /// <summary>
        /// Get check account amount
        /// </summary>
        /// <param name="id">Id aoccout</param>
        /// <returns>ContaCorrente object</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try

            {
                ContaCorrenteRepository repository = new ContaCorrenteRepository();
                ContaCorrente contaCorrente = new ContaCorrente();

                contaCorrente = repository.GetSaldo(id);

                return Ok(contaCorrente);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
