//using Moq;
//using NUnit.Framework;
//using WorkoutHelper.Interfaces;
//using WorkoutHelper.Models;
//using WorkoutHelper.ViewModels;

//namespace WorkoutHelper.Tests.Unit.ViewModels
//{
//    // If you have not gone to WorkoutHelper.Tests/Unit/Models/AnotherExampleDataModelTests.cs, please read that class first.

//    //I'm not going to fully test this entire class, but I will show you how you can use interfaces to MOCK content for testing.

//    //This class requires an external service, which accesses our database, to function. That's no good. Tight dependencies + IO = no unit tests.
    
//    //To fix this we depend on the interface of that external service, and use the IOC Container to give us the correct service at runtime. This allows
//    // us to mock the service and replace it at test time. Lets see an example.
//    public class ShellViewModelTests
//    {
//        private ShellViewModel _viewModel;
//        private Mock<IExampleDataService> _dataService;

//        // Note how we don't have an IExampleDataService we have a Mock<T>.

//        [SetUp]
//        public void Setup()
//        {
//            _dataService = new Mock<IExampleDataService>(); //We can new up mocks no problem.
//            _viewModel = new ShellViewModel(_dataService.Object); //Pass the mock's Object property in as the required service.
//        }

//        [TearDown]
//        public void Teardown()
//        {
//            _viewModel = null;
//            _dataService = null;
//        }

//        // Now we will test the Save function, just to simply see that it calls our service as expected. This would be impossible without
//        // an interface.
//        [Test]
//        public void ShellViewModel_SaveCommandExecuted_CallsSaveOnService()
//        {
//            _dataService.Setup(x => x.Save(It.IsAny<ExampleDataModel>())); //Ok this line looks weird.
//            //What we're doing is telling the mock we wish to setup a method to function at runtime. Then we give it a lambda,
//            // also known as an anonymous function, which says the function we will listen for is Save. However, it needs to know
//            // what sort of parameters we will listen for. We don't actually care what sort of parameters will be passed, so we use the
//            // Helper call It with the generic IsAny<T> to say accept any input. Then we don't tell it what to do afterwards because we
//            // just want the function to be callable, not actual do anything. In short, we said Setup the Save function to any any input of 
//            // type ExampleDataModel, and do nothing with it.

//            _viewModel.SaveCommand.Execute();

//            _dataService.Verify(x => x.Save(It.IsAny<ExampleDataModel>()), Times.Once); //Similar to above. Instead of setting up a function,
//            // we've asked the mock to verify a given function was called. We then gave it the same descriptor as above, saying Save called with any
//            // of type ExampleDataModel, then we told the verification it should only have been called Once using the helper class Times. This basically
//            // says, Hey mock you should fail if Save wasn't called, given any input of this type, once and exactly once.
//        }

//        //This is just a taste of what mocks can do, but you'll quickly realize that Mocks and Interfaces are your friend in C#.
//    }
//}
