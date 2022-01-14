using System;
using System.ComponentModel;
using System.Reflection;

namespace BismillahGraphicsPro.Data
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attribute = (DescriptionAttribute)fi.GetCustomAttribute(typeof(DescriptionAttribute))!;
            return attribute.Description;
        }
    }
}