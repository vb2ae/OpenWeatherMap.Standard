namespace System
{
    public class LangValue : Attribute
    {
        public string Value { get; private set; }

        public LangValue(string value)
        {
            Value = value;
        }
    }
}