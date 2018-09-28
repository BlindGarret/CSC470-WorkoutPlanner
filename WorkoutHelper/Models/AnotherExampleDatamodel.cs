namespace WorkoutHelper.Models
{
    public class AnotherExampleDatamodel
    {
        /// <summary>
        /// A simple testable Function.
        /// </summary>
        /// <returns></returns>
        public int ATestableFunction()
        {
            return 3;
        }
        
        /// <summary>
        /// A tightly bound function which is impossible to unit test.
        /// </summary>
        /// <param name="model"><see cref="ExampleDataModel"/></param>
        /// <returns>The value of the model.</returns>
        public int AFunctionWhichReadsAnExternalClass(ExampleDataModel model)
        {
            return model.Value;
        }
    }
}
