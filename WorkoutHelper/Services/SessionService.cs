using Prism.Events;
using WorkoutHelper.Events;
using WorkoutHelper.Interfaces;

namespace WorkoutHelper.Services
{
    public class SessionService : ISessionService
    {
        #region Properties

        public int UserId { get; set; }

        #endregion

        private readonly IEventAggregator _eventAggregator;

        public SessionService(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            eventAggregator.GetEvent<LoginRequestEvent>().Subscribe(LoginRequested);
        }

        private void LoginRequested(int id)
        {
            UserId = id;
            _eventAggregator.GetEvent<LoginEvent>().Publish(id);
        }
    }
}
