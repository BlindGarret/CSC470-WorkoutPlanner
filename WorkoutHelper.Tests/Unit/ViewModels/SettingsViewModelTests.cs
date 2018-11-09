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
    class SettingsViewModelTests
    {
        private SettingsViewModel _viewModel;
        private Mock<IDataService> _dataServiceMock;
        private Mock<ISessionService> _sessionServiceMock;
        private Mock<IEventAggregator> _eventAggregatorMock;

        [SetUp]
        public void Setup()
        {
            _dataServiceMock = new Mock<IDataService>();
            _sessionServiceMock = new Mock<ISessionService>();
            _eventAggregatorMock = new Mock<IEventAggregator>();
            _viewModel = new SettingsViewModel(_dataServiceMock.Object, _sessionServiceMock.Object,_eventAggregatorMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _viewModel = null;
            _eventAggregatorMock = null;
            _dataServiceMock = null;
        }

        [Test]
        public void SaveCommand_Called_PublishesExpectedEvent()
        {
            var original = new User { Id = 2, FirstName = "B", LastName = "idner", Height = 65, Weight = 130, Avatar = "TEST"};
            var expected = new User { Id = 2, FirstName = "Brandon", LastName = "Widner", Height = 65, Weight = 130, Avatar = "TEST" };
            var eventMock = new Mock<SettingsChangedEvent>();
            _eventAggregatorMock.Setup(x => x.GetEvent<SettingsChangedEvent>()).Returns(eventMock.Object);

        }
    }
}
