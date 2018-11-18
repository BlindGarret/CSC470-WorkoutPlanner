using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WorkoutHelper.Interfaces;
using WorkoutHelper.Models;
using WorkoutHelper.ViewModels;

namespace WorkoutHelper.Tests.Unit.ViewModels
{
    [TestFixture]
    public class PlanningViewModelTests
    {
        private PlanningViewModel _viewModel;
        private Mock<IDataService> _dataService;
        private Mock<ISessionService> _sessionService;
        private Mock<IWorkoutGenerator> _workoutGenerator;

        [SetUp]
        public void Setup()
        {
            _dataService = new Mock<IDataService>();
            _sessionService = new Mock<ISessionService>();
            _workoutGenerator = new Mock<IWorkoutGenerator>();
            _viewModel = new PlanningViewModel(_dataService.Object, _sessionService.Object, _workoutGenerator.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _viewModel = null;
            _workoutGenerator = null;
            _dataService = null;
            _sessionService = null;
        }

        [Test]
        public void TabLoaded_Called_SetsPlansToExpectedCount()
        {
            const int expected = 2;
            const int userId = 42;
            _sessionService.SetupGet(x => x.UserId).Returns(userId);
            _dataService.Setup(x => x.GetPlans(userId)).Returns(new[] { new PlannedWeekday(), new PlannedWeekday() });

            _viewModel.TabLoaded();

            Assert.AreEqual(expected, _viewModel.Plans.Count);
        }

        [Test]
        public void TabLoaded_CalledWhenSelectedDayIsNull_SetsSelectedDayToFirstDay()
        {
            var expected = new PlannedWeekday { Name = "Expected" };
            const int userId = 42;
            _sessionService.SetupGet(x => x.UserId).Returns(userId);
            _dataService.Setup(x => x.GetPlans(userId)).Returns(new[] { expected, new PlannedWeekday { Name = "Nope" } });
            _viewModel.SelectedDay = null;

            _viewModel.TabLoaded();

            Assert.AreEqual(expected.Name, _viewModel.SelectedDay.Name);
        }

        [Test]
        public void TabLoaded_CalledWhenSelectedDayIsNotNull_SetsSelectedDayToExpectedDay()
        {
            var expected = new PlannedWeekday { Name = "Expected" };
            const int userId = 42;
            _sessionService.SetupGet(x => x.UserId).Returns(userId);
            _dataService.Setup(x => x.GetPlans(userId)).Returns(new[] { new PlannedWeekday { Name = "A" }, expected, new PlannedWeekday { Name = "B" } });
            _viewModel.SelectedDay = new ObservablePlannedWeekday(expected);

            _viewModel.TabLoaded();

            Assert.AreEqual(expected.Name, _viewModel.SelectedDay.Name);
        }

        [Test]
        public void SaveCommand_Called_CallsSavePlans()
        {
            const int userId = 42;
            _sessionService.SetupGet(x => x.UserId).Returns(userId);
            _dataService.Setup(x => x.GetPlans(userId)).Returns(new[] { new PlannedWeekday { Name = "A" }, new PlannedWeekday { Name = "B" } });
            _dataService.Setup(x => x.SavePlans(It.IsAny<IEnumerable<PlannedWeekday>>(), userId));

            _viewModel.TabLoaded();
            _viewModel.SaveCommand.Execute();

            _dataService.Verify(x => x.SavePlans(It.IsAny<IEnumerable<PlannedWeekday>>(), userId), Times.Once);
        }

        [Test]
        public void SaveCommand_Called_GetsPlans()
        {
            const int userId = 42;
            _sessionService.SetupGet(x => x.UserId).Returns(userId);
            _dataService.Setup(x => x.GetPlans(userId)).Returns(new[] { new PlannedWeekday { Name = "A" }, new PlannedWeekday { Name = "B" } });
            _dataService.Setup(x => x.SavePlans(It.IsAny<IEnumerable<PlannedWeekday>>(), userId));

            _viewModel.TabLoaded();
            _viewModel.SaveCommand.Execute();

            _dataService.Verify(x => x.GetPlans(userId), Times.Exactly(2)); //Once for original tab load, once for reload.
        }

        [Test]
        public void AddGroupCommand_Called_AddsAGroupToTheWeekday()
        {
            const int expected = 2;
            var weekday = new ObservablePlannedWeekday(new PlannedWeekday());
            weekday.Groups.Add(new ObservablePlannedGroup(new PlannedGroup()));

            _viewModel.AddGroupCommand.Execute(weekday);

            Assert.AreEqual(expected, weekday.Groups.Count);
        }
        
        [Test]
        public void AddExerciseCommand_Called_AddsAnExerciseToTheGroup()
        {
            const int expected = 2;
            var group = new ObservablePlannedGroup(new PlannedGroup());
            group.Exercises.Add(new ObservablePlannedExercise(new PlannedExercise()));

            _viewModel.AddExerciseCommand.Execute(group);

            Assert.AreEqual(expected, group.Exercises.Count);
        }
    }
}
