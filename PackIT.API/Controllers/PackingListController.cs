using Microsoft.AspNetCore.Mvc;
using PackIT.Application.DTO;
using PackIT.Application.Queries;
using PackIT.SharedAbstractions.Commands;
using PackIT.SharedAbstractions.Queries;

namespace PackIT.API.Controllers
{
    public class PackingListController : BaseController
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

            return OkOrNotFound(result);
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<PackingListDto>>> Get([FromBody] SearchPackingLists query)
        {
            var result = await _queryDispatcher.QueryAsync(query);

            return OkOrNotFound(result);
        }
    }
}
