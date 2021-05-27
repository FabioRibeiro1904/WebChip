using Microsoft.AspNetCore.Mvc;
using WebChip.Domain.Commands;
using WebChip.Domain.Handlers;

namespace WebChip.Api.Controllers
{
    [ApiController]
    public class ClienteController : Controller
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult CriarCliente(
        [FromBody] CadastroClienteCommand command,
        [FromServices] ClienteHandler handler)

        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpGet]
        public GenericCommandResult BuscaCpfNome(
        [FromBody] BuscaClienteCommand command,
        [FromServices] ClienteHandler handler)

        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult OfetaCLiente(
        [FromBody] OfertaClienteCommand command,
        [FromServices] ClienteHandler handler)

        {
            return (GenericCommandResult)handler.Handle(command);
        }


    }
}
