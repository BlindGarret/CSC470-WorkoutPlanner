using WorkoutHelper.Models;

namespace WorkoutHelper.Interfaces
{
    /// <summary>
    /// Data Service Interface for data access.
    /// </summary>
    public interface IExampleDataService
    {
        /// <summary>
        /// Load the data model from the data set.
        /// </summary>
        /// <returns><see cref="ExampleDataModel"/></returns>
        ExampleDataModel Load();

        /// <summary>
        /// Save a data model to the data set.
        /// </summary>
        /// <param name="model">Data model to be saved. <see cref="ExampleDataModel"/></param>
        void Save(ExampleDataModel model);
    }
}
