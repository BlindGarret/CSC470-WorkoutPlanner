using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;
using WorkoutHelper.Events;
using WorkoutHelper.Interfaces;

namespace WorkoutHelper.Services
{
    public class SessionService: ISessionService
    {
        #region Properties

        public int UserId { get; set; }

        #endregion

        public SessionService(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<LoginEvent>().Subscribe(id => UserId = id);
        }
    }
}
