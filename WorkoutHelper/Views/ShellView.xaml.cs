using System.Windows;

namespace WorkoutHelper
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        // 99.99999% of the time NOTHING SHOULD GO HERE. We are not using Winforms, and direct eventing is absolutely frowned upon.
        // With VERY RARE exceptions there is always a better way to do things.

        public ShellView()
        {
            InitializeComponent();
        }
    }
}
