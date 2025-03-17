namespace SaveSystem
{
    public readonly struct StringSerializableKey : ISerializableKey
    {
        public string Value { get; }

        public StringSerializableKey(string value)
        {
            Value = value;
        }
        
        public static ISerializableKey Create(string value) => new StringSerializableKey(value);
    }
}