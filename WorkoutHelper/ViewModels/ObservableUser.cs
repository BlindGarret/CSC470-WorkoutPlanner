using System;
using Prism.Mvvm;
using WorkoutHelper.Models;

namespace WorkoutHelper.ViewModels
{
    public class ObservableUser : BindableBase
    {
        #region Properties

        public int Id
        {
            get => _id;
            set
            {
                if(_id != value)
                {
                    _id = value;
                    RaisePropertyChanged(nameof(Id));
                }
            }
        }
        private int _id;

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
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Height = user.Height;
            Weight = user.Weight;
            Avatar = string.IsNullOrEmpty(user.Avatar) ? "/WorkoutHelper;component/Resources/imgs/defaultavatar.png" : user.Avatar;
        }

        public User ToModel()
        {
            return new User
            {
                Id = Id,
                FirstName = FirstName,
                LastName =  LastName,
                Height = Height,
                Weight = Weight,
                Avatar = Avatar
            };
        }
    }
}
