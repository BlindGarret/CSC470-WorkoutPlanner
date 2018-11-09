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
    public class AddUserViewModelTests
    {
        private AddUserViewModel _viewModel;
        private Mock<IDataService> _dataServiceMock;
        private Mock<IEventAggregator> _eventAggregatorMock;

        [SetUp]
        public void Setup()
        {
            _dataServiceMock = new Mock<IDataService>();
            _eventAggregatorMock = new Mock<IEventAggregator>();
            _viewModel = new AddUserViewModel(_dataServiceMock.Object, _eventAggregatorMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _viewModel = null;
            _eventAggregatorMock = null;
            _dataServiceMock = null;
        }

        [Test]
        public void Rendered_Called_ClearsOldUserData()
        {
            const int idToClear = 0909;

            _viewModel.Rendered();
            _viewModel.User.Id = idToClear;
            _viewModel.Rendered();

            Assert.AreNotEqual(idToClear, _viewModel.User.Id);
        }

        [Test]
        public void AddUserCommand_Called_CallsAddUser()
        {
            _dataServiceMock.Setup(x => x.AddUser(It.IsAny<User>()));
            var eventMock = new Mock<LoginRequestEvent>();
            _eventAggregatorMock.Setup(x => x.GetEvent<LoginRequestEvent>()).Returns(eventMock.Object);

            _viewModel.Rendered();
            _viewModel.AddUserCommand.Execute();

            _dataServiceMock.Verify(x => x.AddUser(It.IsAny<User>()),Times.Once);
        }

    }
}
