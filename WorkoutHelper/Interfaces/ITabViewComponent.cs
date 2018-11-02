namespace WorkoutHelper.Interfaces
{
    public interface ITabViewComponent
    {
        string PageName { get; }

        void TabLoaded();
    }
}
