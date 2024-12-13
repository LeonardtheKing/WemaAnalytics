//using WemaAnalytics.Application.Models.Visits;

//namespace WemaAnalytics.Tests.UnitTests.Queries
//{
//    public class GetVisitsQueryTests(TestFixture testFixture) : IClassFixture<TestFixture>
//    {
//        private readonly TestFixture _testFixture = testFixture;

//        [Fact]
//        public async Task Handle_GetVisitsQuery_Success()
//        {
//            // Arrange
//            IUnitOfWork unitOfWork = _testFixture.ServiceProvider.GetRequiredService<IUnitOfWork>();
//            IMapper mapper = _testFixture.ServiceProvider.GetRequiredService<IMapper>();

//            GetVisitsQueryHandler handler = new(unitOfWork, mapper);

//            GetVisitsQuery query = new()
//            {
//                VisitParams = new()
//                {
//                    PageNumber = 1,
//                    PageSize = 10
//                }
//            };

//            // Act
//            BaseResponse<PagedList<VisitModel>> result = await handler.Handle(query, CancellationToken.None);

//            // Assert
//            Assert.Equal(ResponseCodes.Ok, result.StatusCode);
//            Assert.NotNull(result.Data);
//            Assert.Equal("Visits retrieved successfully", result.Message);
//        }
//    }
//}
