using UnityEngine;

namespace SaveSystem
{
    public sealed class SerializableTag: MonoBehaviour, ISerializableKey
    {
        [SerializeField] private GuidSerializableKey guidKey;
        
        public string Value => guidKey.Value;
    }
}