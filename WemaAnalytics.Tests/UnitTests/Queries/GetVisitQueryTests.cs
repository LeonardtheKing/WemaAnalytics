//using WemaAnalytics.Application.Models.Visits;

//namespace WemaAnalytics.Tests.UnitTests.Queries
//{
//    public class GetVisitQueryTests(TestFixture testFixture) : IClassFixture<TestFixture>
//    {
//        private readonly TestFixture _testFixture = testFixture;

//        [Fact]
//        public async Task Handle_GetVisitQuery_Success()
//        {
//            // Arrange
//            IUnitOfWork unitOfWork = _testFixture.ServiceProvider.GetRequiredService<IUnitOfWork>();
//            IMapper mapper = _testFixture.ServiceProvider.GetRequiredService<IMapper>();

//            GetVisitQueryHandler handler = new(unitOfWork, mapper);

//            GetVisitQuery query = new()
//            {
//                Id = Guid.NewGuid() // Replace with existing visit id
//            };

//            // Act
//            BaseResponse<VisitModel> result = await handler.Handle(query, CancellationToken.None);

//            // Assert
//            Assert.Equal(ResponseCodes.Ok, result.StatusCode);
//            Assert.NotNull(result.Data);
//            Assert.Equal("Visit retrieved successfully", result.Message);
//        }

//        [Fact]
//        public async Task Handle_GetVisitQuery_NotFound()
//        {
//            // Arrange
//            IUnitOfWork unitOfWork = _testFixture.ServiceProvider.GetRequiredService<IUnitOfWork>();
//            IMapper mapper = _testFixture.ServiceProvider.GetRequiredService<IMapper>();

//            GetVisitQueryHandler handler = new(unitOfWork, mapper);

//            GetVisitQuery query = new()
//            {
//                Id = Guid.NewGuid() // Replace with non-existing visit id
//            };

//            // Act
//            BaseResponse<VisitModel> result = await handler.Handle(query, CancellationToken.None);

//            // Assert
//            Assert.Equal(ResponseCodes.NotFound, result.StatusCode);
//            Assert.Null(result.Data);
//            Assert.Equal("Visit not found", result.Message);
//        }
//    }
//}
