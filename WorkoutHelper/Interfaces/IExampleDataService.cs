using WorkoutHelper.Models;

namespace WorkoutHelper.Interfaces
{
    public interface IExampleDataService
    {
        ExampleDataModel Load();
        void Save(ExampleDataModel model);
    }
}
