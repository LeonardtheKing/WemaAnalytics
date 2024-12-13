//namespace WemaAnalytics.API.Controllers.v1
//{
//    [Authorize]
//    public class VisitsController(ISender sender) : BaseControllerV1
//    {
//        private readonly ISender _sender = sender;

//        [HttpPost]
//        [ProducesResponseType<BaseResponse<VisitModel>>(200)]
//        [SwaggerOperation(Summary = "Create a new visit", Description = "Create a new visit")]
//        public async Task<IActionResult> CreateVisit(CreateVisitCommand command, CancellationToken cancellation)
//        {
//            command.CurrentUserEmail = LoggedInUserEmail;
//            BaseResponse<VisitModel> response = await _sender.Send(command, cancellation);
//            return HandleResponse(response);
//        }

//        [HttpGet]
//        [ProducesResponseType<BaseResponse<PagedList<VisitModel>>>(200)]
//        [SwaggerOperation(Summary = "Get all visits", Description = "Get all visits")]
//        public async Task<IActionResult> GetVisits([FromQuery]VisitParams visitParams, CancellationToken cancellation)
//        {
//            visitParams.StaffEmail = LoggedInUserEmail;
//            GetVisitsQuery query = new() { VisitParams = visitParams};
//            BaseResponse<PagedList<VisitModel>> response = await _sender.Send(query, cancellation);
//            return HandleResponse(response);
//        }

//        [HttpGet("{id}")]
//        [ProducesResponseType<BaseResponse<VisitModel>>(200)]
//        [SwaggerOperation(Summary = "Get a visit by id", Description = "Get a visit by id")]
//        public async Task<IActionResult> GetVisitById(Guid id, CancellationToken cancellation)
//        {
//            GetVisitQuery query = new() { Id = id };
//            BaseResponse<VisitModel> response = await _sender.Send(query, cancellation);
//            return HandleResponse(response);
//        }

//        [HttpPut("{id}")]
//        [ProducesResponseType<BaseResponse<VisitModel>>(200)]
//        [SwaggerOperation(Summary = "Update a visit", Description = "Update a visit")]
//        public async Task<IActionResult> UpdateVisit(Guid id, UpdateVisitCommand command, CancellationToken cancellation)
//        {
//            command.Id = id;
//            command.CurrentUserEmail = LoggedInUserEmail;
//            BaseResponse<VisitModel> response = await _sender.Send(command, cancellation);
//            return HandleResponse(response);
//        }

//        [HttpDelete("{id}")]
//        [ProducesResponseType<BaseResponse<string>>(200)]
//        [SwaggerOperation(Summary = "Delete a visit", Description = "Delete a visit")]
//        public async Task<IActionResult> DeleteVisit(Guid id, CancellationToken cancellation)
//        {
//            DeleteVisitCommand command = new() { Id = id, CurrentUserEmail = LoggedInUserEmail };
//            BaseResponse<string> response = await _sender.Send(command, cancellation);
//            return HandleResponse(response);
//        }
//    }
//}
