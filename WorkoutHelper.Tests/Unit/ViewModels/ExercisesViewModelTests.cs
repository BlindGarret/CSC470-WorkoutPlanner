using System.Linq;
using Moq;
using NUnit.Framework;
using WorkoutHelper.Interfaces;
using WorkoutHelper.Models;
using WorkoutHelper.ViewModels;

namespace WorkoutHelper.Tests.Unit.ViewModels
{
    [TestFixture]
    class ExercisesViewModelTests
    {
        private ExercisesViewModel _viewModel;
        private Mock<IDataService> _dataServiceMock;
        private Mock<ISessionService> _sessionServiceMock;

        [SetUp]
        public void Setup()
        {
            _dataServiceMock = new Mock<IDataService>();
            _sessionServiceMock = new Mock<ISessionService>();
            _viewModel = new ExercisesViewModel(_dataServiceMock.Object, _sessionServiceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _viewModel = null;
            _sessionServiceMock = null;
            _dataServiceMock = null;
        }

        [Test]
        public void TabLoaded_Called_GetsExercisesFromDataService()
        {
            _dataServiceMock.Setup(x => x.GetExercises(It.IsAny<int>())).Returns(Enumerable.Empty<Exercise>());

            _viewModel.TabLoaded();

            _dataServiceMock.Verify(x => x.GetExercises(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void TabLoaded_Called_GetsExercisesFromDataServiceWithCorrectUserId()
        {
            const int expected = 42;
            _sessionServiceMock.SetupGet(x => x.UserId).Returns(expected);
            _dataServiceMock.Setup(x => x.GetExercises(It.IsAny<int>())).Returns(Enumerable.Empty<Exercise>());

            _viewModel.TabLoaded();

            _dataServiceMock.Verify(x => x.GetExercises(expected), Times.Once);
        }

        [Test]
        public void TabLoaded_Called_SetsExercisesFromDataInAlphabeticalOrderByName()
        {
            _dataServiceMock.Setup(x => x.GetExercises(It.IsAny<int>())).Returns(new []
            {
                new Exercise { Name = "a" },
                new Exercise { Name = "b" },
                new Exercise { Name = "c" }
            });

            _viewModel.TabLoaded();
            var ordered = _viewModel.Exercises.OrderBy(x => x.Name);

            Assert.That(_viewModel.Exercises, Is.EquivalentTo(ordered));
        }

        [Test]
        public void EnableExerciseCommand_Called_CallsEnableExerciseWithExpectedId()
        {
            const int expected = 42;
            _dataServiceMock.Setup(x => x.EnableExercise(expected, It.IsAny<int>()));

            _viewModel.EnableExerciseCommand.Execute(new Exercise {Id = expected});


            _dataServiceMock.Verify(x => x.EnableExercise(expected, It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void EnableExerciseCommand_Called_CallsEnableExerciseWithExpectedUserId()
        {
            const int expected = 42;
            _sessionServiceMock.SetupGet(x => x.UserId).Returns(expected);
            _dataServiceMock.Setup(x => x.EnableExercise(It.IsAny<int>(), expected));

            _viewModel.EnableExerciseCommand.Execute(new Exercise());


            _dataServiceMock.Verify(x => x.EnableExercise(It.IsAny<int>(), expected), Times.Once);
        }

        [Test]
        public void DisableExerciseCommand_Called_CallsDisableExerciseWithExpectedId()
        {
            const int expected = 42;
            _dataServiceMock.Setup(x => x.DisableExercise(expected, It.IsAny<int>()));

            _viewModel.DisableExerciseCommand.Execute(new Exercise { Id = expected });


            _dataServiceMock.Verify(x => x.DisableExercise(expected, It.IsAny<int>()), Times.Once);
        }
    }
}
