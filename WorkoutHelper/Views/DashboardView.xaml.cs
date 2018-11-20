using System.Windows;
using System.Windows.Controls;
using WorkoutHelper.ViewModels;

namespace WorkoutHelper.Views
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();
        }

        private void UpdateLineGraph(object sender, DependencyPropertyChangedEventArgs e)
        {
            var vm = e.NewValue as DashboardViewModel;
            if (vm == null)
            {
                return;
            }

            vm.LineGraph = WeightGraph;
            vm.TabLoaded();
        }
    }
}
