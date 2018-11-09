namespace WorkoutHelper.Interfaces
{
    public interface IPageViewComponent
    {
        /// <summary>
        /// Notifier that a given page component is being renderer.
        /// </summary>
        void Rendered();
    }
}
