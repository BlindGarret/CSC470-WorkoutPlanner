using NUnit.Framework;
using WorkoutHelper.Models;

namespace WorkoutHelper.Tests.Unit.Models
{
    public class AnotherExampleDataModelTests
    {
        //this is a test class. It will contain a few components:
        // * A set of private variables comprised of a set of mocks and the class we are testing
        // * A Setup method which is called before every test
        // * A Teardown Method which is called after every test
        // * A Set of test methods named as such "NameOfClassToTest_ActionYouAreTesting_ExpectedResultDescription"
        
        // Each testable class is to have at LEAST a set of unit tests testing the public functions. What actually defines
        // a testable class is a bit nebulous. Usually every class you make should be considered testable until proven otherwise.
        // A class becomes un-testable, from a unit test perspective, when it gets too close to IO sources in the code (aka user input, graphical rendering
        // network, file reading). This is why we always include an extremely thin layer (usually as a service) which acts as a tiny bit of untestable code
        // between you and the IO sections of the code. Honestly, testing is an art form and it will take a bit to really get what you're doing. However, it's
        // by far one of the most important skills to get, as it's the skill which real world devs wish student knew coming out of college.

        //This class in particular is a unit test. That term is fluid and means many things to many people. For our case I'm using the strictest definition of
        // unit test I know. Here are the rules I was taught, and have slowly improved throughout my career.

        //Unit test rules:
        // 1. Unit tests test a single unit of code. This is usually a class, but in rare situations can be a small set of classes. However, usually it's a class.
        // 2. Unit tests may NEVER touch IO under any circumstances. That means reading from the file system, network, console, databases, or apis.
        //      * This is because even the best coded IO code can intermittently fail for reasons completely outside your control, such as the OS. See rule 3 for why this is bad.
        // 3. Unit tests must ALWAYS be able to run and pass from a clean checkout. No external dependencies. If the project builds the unit tests MUST pass.
        //      * This is because unit tests are meant to act as a security blanket for other developers. If a developer can't be comfortable in trusting unit test results then
        //          they will not be comfortable that the newest changes didn't break something.
        // 4. Unit tests may not contain multiple asserts.
        //      * This is fairly hotly debated, but for right now It's better to stay simple. One Test One Assert.
        // 5. Unit tests may not contain execution control logic. So no Ifs, Loops, Switches, or anything of that sort.
        //      * Unit tests are generally harder to understand than code at first for developers anyway, so clarity of purpose is hugely important.
        //      * This is also fairly hotly debated, but once again, keep it simple.
        // 6. Unit test may not construct classes, other than the one it is testing or Mock Classes. Basically if you are using the 'new' keyword, followed by a class without MOCK
        //    in the name, you're wrong.
        //      * Due to the nature of C#, constructors in classes are slightly dangerous in what they are allowed to do.
        //      * Plus this helps keep track of the One unit for one set of tests rule.
        // 7. Newing up structures (struct) is fine. Just make sure if you made the struct that you chose for it to be a struct for the right reasons.
        //      * Structs are not just different names for classes in C#, unlike in C++. The differences are neither subtle nor small.

        // Those are the major rules. There are of course other patterns and smaller rules you'll bump into as you learn. It will seem like a lot to take in at first, but really
        // its fairly easy to get used to it. Once you figure out how mocking works, and why IOC makes unit tests really easy to write, you will quickly find testing is second
        // and obvious.

        // We'll be using the AAA style of testing. Which is basically just a format for setting up test functions. Feel free to look it up but it'll be obvious in the examples.

        // Any questions, feel free to ask, otherwise here's some simple examples.

        //Here is our testable class.
        private AnotherExampleDatamodel _model;
        
        [SetUp]
        public void Setup()
        {
            // initialize the class we wish to test. This is the only allow 'new' in the test, unless its a Mock or a Struct.
            _model = new AnotherExampleDatamodel();
        }

        [TearDown]
        public void TearDown()
        {
            //Destroy your objects in reverse order of initialization.
            _model = null;
        }

        [Test]
        public void AnotherExampleDataModel_CallATestableFunction_ReturnsExpectedValue()
        {
            //Arrange - This section is where you define your known variable for use in the act stage
            const int expected = 3;

            //Act - This section is where you act upon your test circumstances, and collect your data.
            var value = _model.ATestableFunction();

            //Assert - Here we asset that the test results are as expected.
            Assert.AreEqual(expected, value);
        } // it's that easy

        //Notice I'm NOT testing the other available function. Please see the Integration test for this class to see why.

    }
}
