using System;
using OpenWeatherMap.Standard.Attributes;

namespace OpenWeatherMap.Standard.Extensions
{
    public static class LangValueExtension
    {
        public static string GetStringValue(this Enum value)
        {
            var stringValue = value.ToString();
            var type = value.GetType();
            var fieldInfo = type.GetField(value.ToString());

            if (fieldInfo.GetCustomAttributes(typeof(LangValue), false) is LangValue[] attrs && attrs.Length > 0)
                stringValue = attrs[0].Value;

            return stringValue;
        }
    }
}