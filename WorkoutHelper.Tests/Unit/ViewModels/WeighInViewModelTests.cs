using System;
using System.Linq;
using Moq;
using NUnit.Framework;
using Prism.Events;
using WorkoutHelper.Events;
using WorkoutHelper.Interfaces;
using WorkoutHelper.Models;
using WorkoutHelper.ViewModels;

namespace WorkoutHelper.Tests.Unit.ViewModels
{
    [TestFixture]
    class WeighInViewModelTests
    {
        private WeighInViewModel _viewModel;
        private Mock<IDataService> _dataServiceMock;
        private Mock<ISessionService> _sessionServiceMock;
        private Mock<IEventAggregator> _eventAggregatorMock;

        [SetUp]
        public void Setup()
        {
            _dataServiceMock = new Mock<IDataService>();
            _sessionServiceMock = new Mock<ISessionService>();
            _viewModel = new WeighInViewModel(_dataServiceMock.Object, _sessionServiceMock.Object);
            _eventAggregatorMock = new Mock<IEventAggregator>();
        }

        [TearDown]
        public void TearDown()
        {
            _viewModel = null;
            _sessionServiceMock = null;
            _dataServiceMock = null;
        }

        [Test]
        public void TabLoaded_Called_GetsWeightFromDataService()
        {
            _dataServiceMock.Setup(x => x.GetWeight(It.IsAny<int>())).Returns(1.0);

            _viewModel.TabLoaded();

            _dataServiceMock.Verify(x => x.GetWeight(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void TabLoaded_Called_GetsDateFromDataService()
        {
            DateTime expected = DateTime.Today;
            _dataServiceMock.Setup(x => x.GetDate()).Returns(expected);

            _viewModel.TabLoaded();

            _dataServiceMock.Verify(x => x.GetDate(), Times.Once);
        }

        [Test]
        public void SaveCommand_Called_SaveWeight()
        {
            var eventMock = new Mock<WeighInAddedEvent>();
            eventMock.Setup(x => x.Publish());
            _eventAggregatorMock.Setup(x => x.GetEvent<WeighInAddedEvent>()).Returns(eventMock.Object);
            _dataServiceMock.Setup(x => x.SaveWeight(It.IsAny<User>(), It.IsAny<double>()));

            _viewModel.SaveCommand.Execute();

            _dataServiceMock.Verify(x => x.SaveWeight(It.IsAny<User>(), It.IsAny<double>()), Times.Once);
        }

        [Test]
        public void SaveCommand_Called_SaveWeighIn()
        {
            var eventMock = new Mock<WeighInAddedEvent>();
            eventMock.Setup(x => x.Publish());
            _eventAggregatorMock.Setup(x => x.GetEvent<WeighInAddedEvent>()).Returns(eventMock.Object);
            _dataServiceMock.Setup(x => x.SaveWeighIn(It.IsAny<WeighIn>(), It.IsAny<int>()));

            _viewModel.SaveCommand.Execute();

            _dataServiceMock.Verify(x => x.SaveWeighIn(It.IsAny<WeighIn>(), It.IsAny<int>()), Times.Once);
        }
    }
}
