using System.Reflection;

namespace System
{
    public static class LangValueExtension
    {
        public static string GetStringValue(this Enum value)
        {
            string stringValue = value.ToString();
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            LangValue[] attrs = fieldInfo.
                GetCustomAttributes(typeof(LangValue), false) as LangValue[];

            if (attrs.Length > 0)
            {
                stringValue = attrs[0].Value;
            }

            return stringValue;
        }
    }
}