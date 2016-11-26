using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace YunKe.AdminPanel.Help
{
    public static class SelectListItems
    {
        /// <summary>
        /// Gets an list of <see cref="SelectListItem"/> items from an enum type.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static IList<SelectListItem> FromEnum<TEnum>()
        {
            Type enumType = typeof(TEnum);
            return FromEnum(enumType);
        }

        /// <summary>
        /// Gets an list of <see cref="SelectListItem"/> items from an enum type, and provides a default value of this enum.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="selectedValue"></param>
        /// <returns></returns>
        public static IList<SelectListItem> FromEnum<TEnum>(TEnum selectedValue)
        {
            Type enumType = typeof(TEnum);
            return FromEnum(enumType, selectedValue.ToString());
        }

        /// <summary>
        /// Gets an list of <see cref="SelectListItem"/> items from an enum type, and provides a default value of this enum.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="selectedValue"></param>
        /// <returns></returns>
        public static IList<SelectListItem> FromEnum<TEnum>(string selectedValue)
        {
            Type enumType = typeof(TEnum);
            return FromEnum(enumType, selectedValue);
        }

        /// <summary>
        /// Gets an list of <see cref="SelectListItem"/> items from an enum type, and provides a default value of this enum.
        /// </summary>
        /// <param name="enumType">Type of the enum</typeparam>
        /// <returns></returns>
        public static IList<SelectListItem> FromEnum(Type enumType)
        {
            return FromEnum(enumType, null);
        }


        /// <summary>
        /// Gets an list of <see cref="SelectListItem"/> items from an enum type, and provides a default string value of this enum.
        /// </summary>
        /// <param name="enumType">Type of the enum</typeparam>
        /// <param name="selectedValue">A default string value of this enum</param>
        /// <returns></returns>
        public static IList<SelectListItem> FromEnum(Type enumType, string selectedValue)
        {
            IList<SelectListItem> list = new List<SelectListItem>();

            foreach (var field in enumType.GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                var descAttr = field.GetCustomAttributes(typeof(DescriptionAttribute), false)
                                    .OfType<DescriptionAttribute>()
                                    .FirstOrDefault();

                var text = descAttr == null ? field.Name : descAttr.Description;
                var value = field.Name;
                var selected = selectedValue != null && (value == selectedValue);

                list.Add(new SelectListItem { Text = text, Value = value, Selected = selected });
            }

            return list;
        }
    }
}