using UnityEngine;

namespace SaveSystem
{
    public sealed class GuidSerializableTag: MonoBehaviour, ISerializableKey
    {
        [SerializeField] private GuidSerializableKey guidKey;
        
        public string Value => guidKey.Value;
    }
}