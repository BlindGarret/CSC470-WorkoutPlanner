using NUnit.Framework;
using WorkoutHelper.Models;

namespace WorkoutHelper.Tests.Integration.Models
{
    public class AnotherExampleDataModelTests
    {
        // If you have not gone to WorkoutHelper.Tests/Unit/Models/AnotherExampleDataModelTests.cs, please read that class first.

        // Integration tests are not unit tests. They are tests of multiple units, and act as dumping grounds for tests which
        // aren't "pure" enough for unit tests. As a general rule most of the rules of Unit tests apply except that it's completely
        // ok to include multiple classes in integration tests. Also Integration tests can be used when you NEED to test a functionality
        // you can't isolate enough to call a unit test. For example, if you absolutely NEED to read a data document for an end to end
        // test, this could be an integration test, even though it touches the IO.

        // That being said, don't just use integration testing to hide all of your unit testing sins. Always try to make things Unit tests
        // before making them integration tests.

        private AnotherExampleDatamodel _model;

        [SetUp]
        public void SetUp()
        {
            _model = new AnotherExampleDatamodel();
        }

        [TearDown]
        public void Teardown()
        {
            _model = null;
        }

        //note how I have to new up an external class and pass it into this method. This means it can't be a
        // unit test. Since it doesn't have an interface, or any virtual members, it can't be mocked. This means
        // it needs to be an integration test, and acts as a suggestion that these two classes may be too tightly bound together.
        [Test]
        public void AnotherExampleDataModel_AFunctionWhichReadsAnExternalClassCalledWithGiven_ReturnsExpected()
        {
            //see the AAA format. You don't need to label the sections, just add spaces between them.
            const int expected = 0;
            var otherModel = new ExampleDataModel()
            {
                Value = expected
            };

            var value = _model.AFunctionWhichReadsAnExternalClass(otherModel);

            Assert.AreEqual(expected, value);
        }
    }
}
