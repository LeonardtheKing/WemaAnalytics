//namespace WemaAnalytics.Tests.UnitTests.Commands
//{
//    public class DeleteVisitCommandTests(TestFixture testFixture) : IClassFixture<TestFixture>
//    {
//        private readonly TestFixture _testFixture = testFixture;

//        [Fact]
//        public async Task Handle_DeleteVisit_Success()
//        {
//            // Arrange
//            IUnitOfWork unitOfWork = _testFixture.ServiceProvider.GetRequiredService<IUnitOfWork>();

//            DeleteVisitCommandHandler handler = new(unitOfWork);

//            DeleteVisitCommand deleteVisitCommand = new()
//            {
//                Id = Guid.NewGuid(), // Replace with valid Id
//            };

//            // Act
//            BaseResponse<string> result = await handler.Handle(deleteVisitCommand, CancellationToken.None);

//            // Assert
//            Assert.Equal(ResponseCodes.Ok, result.StatusCode);
//            Assert.Equal("Visit deleted successfully", result.Message);
//        }

//        [Fact]
//        public async Task Handle_DeleteVisit_NotFound()
//        {
//            // Arrange
//            IUnitOfWork unitOfWork = _testFixture.ServiceProvider.GetRequiredService<IUnitOfWork>();

//            DeleteVisitCommandHandler handler = new(unitOfWork);

//            DeleteVisitCommand deleteVisitCommand = new()
//            {
//                Id = Guid.NewGuid(), // Replace with invalid Id
//            };

//            // Act
//            BaseResponse<string> result = await handler.Handle(deleteVisitCommand, CancellationToken.None);

//            // Assert
//            Assert.Equal(ResponseCodes.NotFound, result.StatusCode);
//            Assert.Equal("Visit not found", result.Message);
//        }
//    }
//}
