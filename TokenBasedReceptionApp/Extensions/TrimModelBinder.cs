using System.Web.Mvc;

namespace TokenBasedReceptionApp.Extensions
{
    public class TrimModelBinder : DefaultModelBinder
    {
        /// <summary>
        /// Sets value to property after performing left and right trim
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="bindingContext"></param>
        /// <param name="propertyDescriptor"></param>
        /// <param name="value"></param>
        protected override void SetProperty(ControllerContext controllerContext,
          ModelBindingContext bindingContext,
          System.ComponentModel.PropertyDescriptor propertyDescriptor,
          object value)
        {
            // Identifies string property
            if (propertyDescriptor.PropertyType == typeof(string))
            {
                // Trims the value if not null
                var stringValue = (string)value;
                if (!string.IsNullOrEmpty(stringValue))
                {
                    stringValue = stringValue.Trim();
                }

                value = stringValue;
            }

            // Actually sets the value to property
            base.SetProperty(controllerContext, bindingContext,
                                propertyDescriptor, value);
        }
    }
}