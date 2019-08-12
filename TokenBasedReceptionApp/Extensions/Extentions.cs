using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace TokenBasedReceptionApp.Extensions
{
    public static class Extentions
    {
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
            TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static IEnumerable<Error> AllErrors(this ModelStateDictionary modelState)
        {
            var result = new List<Error>();
            var erroneousFields = modelState.Where(ms => ms.Value.Errors.Any())
                                            .Select(x => new { x.Key, x.Value.Errors });

            foreach (var erroneousField in erroneousFields)
            {
                var fieldKey = erroneousField.Key;
                var fieldErrors = erroneousField.Errors
                                   .Select(error => new Error(fieldKey, error.ErrorMessage));
                result.AddRange(fieldErrors);
            }

            return result;
        }

        /// <summary>
        /// Get to end time of the day
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime EndOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }

        /// <summary>
        /// Get start time of the day
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime StartOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }

        public static DateTime ToUTCDateTime(this DateTime localDateTime)
        {
            TimeZoneInfo indianTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            localDateTime = DateTime.SpecifyKind(localDateTime, DateTimeKind.Unspecified);
            DateTime utcDateTime = TimeZoneInfo.ConvertTimeToUtc(localDateTime, indianTimeZone);
            return utcDateTime;
        }
        public static DateTime? ToUTCDateTime(this DateTime? localDateTime)
        {
            if (localDateTime.HasValue)
            {
                TimeZoneInfo indianTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                localDateTime = DateTime.SpecifyKind(localDateTime.Value, DateTimeKind.Unspecified);
                DateTime utcDateTime = TimeZoneInfo.ConvertTimeToUtc(localDateTime.Value, indianTimeZone);
                return utcDateTime;
            }
            return null;            
        }

        public static DateTime ToLocalDateTime(this DateTime utcDateTime)
        {
            TimeZoneInfo indianTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            utcDateTime = DateTime.SpecifyKind(utcDateTime, DateTimeKind.Utc);
            DateTime easternDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, indianTimeZone);
            return easternDateTime;
        }
        public static DateTime? ToLocalDateTime(this DateTime? utcDateTime)
        {
            if(utcDateTime.HasValue)
            {
                TimeZoneInfo indianTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                utcDateTime = DateTime.SpecifyKind(utcDateTime.Value, DateTimeKind.Utc);
                DateTime easternDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime.Value, indianTimeZone);
                return easternDateTime;
            }
            return null;
        }

        /// <summary>
        /// Convert a list of items to a select list
        /// </summary>
        public static List<SelectListItem> ToSelectList<T>(
          this IEnumerable<T> enumerable,
          Func<T, string> text,
          Func<T, string> value,
          String selectedValue,
          String defaultOption)
        {
            var items = enumerable.Select(f => new SelectListItem()
            {
                Selected = selectedValue == value(f),
                Text = text(f),
                Value = value(f)
            }).ToList();

            if (!(defaultOption == null))
            {
                items.Insert(0, new SelectListItem()
                {                   
                    Text = defaultOption,
                    Value = ""
                });
            }

            return items.ToList();
        }
        
        //For sql "Like" comparison in linq to objects
        public static bool Like(this string s, string pattern)
        {
            //Find the pattern anywhere in the string
            pattern = ".*" + pattern + ".*";

            return Regex.IsMatch(s, pattern, RegexOptions.IgnoreCase);
        }
    }

    //public static class ControllerExtensions
    //{
    //    public static ToastMessage AddToastMessage(this Controller controller, string title, string message, ToastType toastType = ToastType.Info)
    //    {
    //        Toastr toastr = controller.TempData["Toastr"] as Toastr;
    //        toastr = toastr ?? new Toastr();

    //        var toastMessage = toastr.AddToastMessage(title, message, toastType);
    //        controller.TempData["Toastr"] = toastr;
    //        return toastMessage;
    //    }
    //}

    public class Error
    {
        public Error(string key, string message)
        {
            Key = key;
            Message = message;
        }

        public string Key { get; set; }
        public string Message { get; set; }
    }

}