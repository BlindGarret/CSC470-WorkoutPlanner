using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    class LoginViewModelTests
    {
        private LoginViewModel _viewModel;
        private Mock<IDataService> _dataServiceMock;
        private Mock<IEventAggregator> _eventAggregatorMock;

        [SetUp]
        public void Setup()
        {
            _dataServiceMock = new Mock<IDataService>();
            _eventAggregatorMock = new Mock<IEventAggregator>();
            _viewModel = new LoginViewModel(_eventAggregatorMock.Object, _dataServiceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _viewModel = null;
            _eventAggregatorMock = null;
            _dataServiceMock = null;
        }

        [Test]
        public void Rendered_Called_SetsUsersToExpectedSet()
        {
            var expected = new[] {1, 2};
            var users = new[] { new User { Id = 1 }, new User { Id = 2 } };
            _dataServiceMock.Setup(x => x.GetUsers()).Returns(users);

            _viewModel.Rendered();
            var set = _viewModel.Users.Select(x => x.Id);

            Assert.That(expected, Is.EquivalentTo(set));
        }

        [Test]
        public void AddUserCommand_Called_PublishesExpectedEvent()
        {
            var eventMock = new Mock<AddUserRequestedEvent>();
            _eventAggregatorMock.Setup(x => x.GetEvent<AddUserRequestedEvent>()).Returns(eventMock.Object);
            eventMock.Setup(x => x.Publish());

            _viewModel.AddUserCommand.Execute();

            eventMock.Verify(x => x.Publish(), Times.Once);
        }

        [Test]
        public void LoginCommand_Called_PublishesExpectedEvent()
        {
            var expected = 42;
            var eventMock = new Mock<LoginRequestEvent>();
            _eventAggregatorMock.Setup(x => x.GetEvent<LoginRequestEvent>()).Returns(eventMock.Object);
            eventMock.Setup(x => x.Publish(expected));

            _viewModel.LoginCommand.Execute(new ObservableUser(new User() { Id = expected }));

            eventMock.Verify(x => x.Publish(expected), Times.Once);
        }
    }
}
