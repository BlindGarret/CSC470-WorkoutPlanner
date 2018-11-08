using System;
using Prism.Mvvm;
using WorkoutHelper.Models;

namespace WorkoutHelper.ViewModels
{
    public class ObservableUser : BindableBase
    {
        #region Properties

        public int UserId
        {
            get => _userId;
            set
            {
                if(_userId != value)
                {
                    _userId = value;
                    RaisePropertyChanged(nameof(UserId));
                }
            }
        }
        private int _userId;

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    RaisePropertyChanged(nameof(FirstName));
                }
            }
        }

        private string _firstName;

        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    RaisePropertyChanged(nameof(LastName));
                }
            }
        }

        private string _lastName;

        public int Height
        {
            get => _height;
            set
            {
                if (_height != value)
                {
                    _height = value;
                    RaisePropertyChanged(nameof(Height));
                }
            }
        }

        private int _height;

        public double Weight
        {
            get => _weight;
            set
            {
                if (Math.Abs(_weight - value) > .0001)
                {
                    _weight = value;
                    RaisePropertyChanged(nameof(Weight));
                }
            }
        }

        private double _weight;

        public string Avatar
        {
            get => _avatar;
            set
            {
                if (_avatar != value)
                {
                    _avatar = value;
                    RaisePropertyChanged(nameof(Avatar));
                }
            }
        }

        private string _avatar;

        #endregion

        public ObservableUser(User user)
        {
            UserId = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Height = user.Height;
            Weight = user.Weight;
            Avatar = user.Avatar;
        }

        public User ToModel()
        {
            return new User
            {
                FirstName = FirstName,
                LastName =  LastName,
                Height = Height,
                Weight = Weight,
                Avatar = Avatar
            };
        }
    }
}
