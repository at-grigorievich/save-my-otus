namespace SaveSystem
{
    public interface ISerializableRepository
    {
        void SetData(ISerializableKey key, ISerializable data);
        bool TryGetData<T>(ISerializableKey key, out T result) where T : ISerializable, new();

        void SerializeState();
        void DeserializeState();
    }

    public interface ISerializeRepositoryClearable
    {
        void Clear();
    }
}