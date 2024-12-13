//using WemaAnalytics.Application.Models.Visits;

//namespace WemaAnalytics.Tests.UnitTests.Commands
//{
//    public class UpdateVisitCommandTests(TestFixture testFixture) : IClassFixture<TestFixture>
//    {
//        private readonly TestFixture _testFixture = testFixture;

//        [Fact]
//        public async Task Handle_UpdateVisit_Success()
//        {
//            // Arrange
//            IUnitOfWork unitOfWork = _testFixture.ServiceProvider.GetRequiredService<IUnitOfWork>();
//            IMapper mapper = _testFixture.ServiceProvider.GetRequiredService<IMapper>();

//            UpdateVisitCommandHandler handler = new(unitOfWork, mapper);

//            UpdateVisitCommand updateVisitCommand = new()
//            {
//                Id = Guid.NewGuid(), // Replace with valid Id
//                CompanyName = "Test Company",
//                Venue = "Test Venue",
//                Purpose = "Test Purpose",
//                Date = DateTime.Now,
//                Time = TimeSpan.FromHours(10)
//            };

//            // Act
//            BaseResponse<VisitModel> result = await handler.Handle(updateVisitCommand, CancellationToken.None);

//            // Assert
//            Assert.Equal(ResponseCodes.Ok, result.StatusCode);
//            Assert.NotNull(result.Data);
//            Assert.Equal("Visit schedule updated successfully", result.Message);
//        }

//        [Fact]
//        public async Task Handle_UpdateVisit_NotFound()
//        {
//            // Arrange
//            IUnitOfWork unitOfWork = _testFixture.ServiceProvider.GetRequiredService<IUnitOfWork>();
//            IMapper mapper = _testFixture.ServiceProvider.GetRequiredService<IMapper>();

//            UpdateVisitCommandHandler handler = new(unitOfWork, mapper);

//            UpdateVisitCommand updateVisitCommand = new()
//            {
//                Id = Guid.NewGuid(), // Replace with invalid Id
//                CompanyName = "Test Company",
//                Venue = "Test Venue",
//                Purpose = "Test Purpose",
//                Date = DateTime.Now,
//                Time = TimeSpan.FromHours(10)
//            };

//            // Act
//            BaseResponse<VisitModel> result = await handler.Handle(updateVisitCommand, CancellationToken.None);

//            // Assert
//            Assert.Equal(ResponseCodes.NotFound, result.StatusCode);
//            Assert.Null(result.Data);
//            Assert.Equal("Visit not found", result.Message);
//        }
//    }
//}
