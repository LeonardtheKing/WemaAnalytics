//using WemaAnalytics.Application.Models.Visits;

//namespace WemaAnalytics.Tests.UnitTests.Commands
//{
//    public class CreateVisitCommandTests(TestFixture testFixture) : IClassFixture<TestFixture>
//    {
//        private readonly TestFixture _testFixture = testFixture;

//        [Fact]
//        public async Task Handle_CreateVisit_Success()
//        {
//            // Arrange
//            IUnitOfWork unitOfWork = _testFixture.ServiceProvider.GetRequiredService<IUnitOfWork>();
//            IMapper mapper = _testFixture.ServiceProvider.GetRequiredService<IMapper>();

//            CreateVisitCommandHandler handler = new(unitOfWork, mapper);

//            CreateVisitCommand createVisitCommand = new()
//            {
//                CompanyName = "Test Company",
//                Venue = "Test Venue",
//                Purpose = "Test Purpose",
//                Date = DateTime.Now,
//                Time = TimeSpan.FromHours(10)
//            };

//            // Act
//            BaseResponse<VisitModel> result = await handler.Handle(createVisitCommand, CancellationToken.None);

//            // Assert
//            Assert.Equal(ResponseCodes.Ok, result.StatusCode);
//            Assert.NotNull(result.Data);
//            Assert.Equal("Visit schedule created", result.Message);
//        }
//    }
//}
