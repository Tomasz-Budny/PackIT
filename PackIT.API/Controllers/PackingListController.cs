using Microsoft.AspNetCore.Mvc;
using PackIT.Application.DTO;
using PackIT.Application.Queries;
using PackIT.SharedAbstractions.Commands;
using PackIT.SharedAbstractions.Queries;

namespace PackIT.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackingListController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;


        public PackingListController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PackingListDto>> Get([FromRoute] GetPackingList query)
        {
            var result = await _queryDispatcher.QueryAsync(query);

            if(result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<PackingListDto>>> Get([FromBody] SearchPackingLists query)
        {
            var result = await _queryDispatcher.QueryAsync(query);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
