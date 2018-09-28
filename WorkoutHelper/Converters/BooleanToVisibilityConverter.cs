using System.Windows;

//This converter uses the base class to allow us to transform boolean values to visibility values.

//Visibility is not a boolean type, it is it's own enumeration to allow for hidden versus collapsed, so we need to 
// convert the value to something useful.

namespace WorkoutHelper.Converters
{
    public class BooleanToVisibilityConverter : BooleanConverter<Visibility>
    {
        public BooleanToVisibilityConverter() :
            base(Visibility.Visible, Visibility.Collapsed)
        { }
    }
}