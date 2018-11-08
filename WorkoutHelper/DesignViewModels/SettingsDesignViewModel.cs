﻿using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using WorkoutHelper.Models;
using WorkoutHelper.ViewModels;

namespace WorkoutHelper.DesignViewModels
{
    public class SettingsDesignViewModel : BindableBase
    {

        #region Properties

        public string PageName { get; set; } = "Settings";

        public ObservableUser User { get; set; }

        public ObservableWeighIn WeighIn { get; set; }

        #endregion

        #region Commands

        public DelegateCommand SaveCommand { get; set; }

        #endregion
    }
}
