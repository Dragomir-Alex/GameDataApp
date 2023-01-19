using FakeItEasy;
using GameDataApp.Controllers;
using GameDataApp.DAL;
using GameDataApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameDataApp.Tests
{
    public class GameDataControllerTests
    {
        private IUnitOfWork _unitOfWork;
        private ItemsController _controller;

        [SetUp]
        public void Setup()
        {
            _unitOfWork = A.Fake<IUnitOfWork>();
            _controller = new ItemsController(_unitOfWork);
        }

        [Test]
        public async Task GetItems_ReturnsTheCorrectItems()
        {
            // Arrange
            var expectedItems = A.CollectionOfDummy<Item>(5).AsEnumerable();
            A.CallTo(() => _unitOfWork.ItemRepository.Get(null, null, null))
                .Returns(Task.FromResult(expectedItems));

            // Act
            var actionResult = await _controller.GetItems();

            // Assert
            var result = actionResult.Result as OkObjectResult;
            var responseItems = result.Value as IEnumerable<Item>;
            NUnit.Framework.Assert.IsNotNull(responseItems);
        }
    }
}