using System;

namespace OpenWeatherMap.Standard.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public sealed class LangValue : Attribute
    {
        public LangValue(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}