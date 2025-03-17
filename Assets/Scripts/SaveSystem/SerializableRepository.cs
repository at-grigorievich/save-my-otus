using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace SaveSystem
{
    public class SerializableRepository: ISerializableRepository, ISerializeRepositoryClearable
    {
        private const string STATE_PATH = "state-path";
        
        private Dictionary<string, string> _serializableState = new();
        
        public void SetData(ISerializableKey key, ISerializable data)
        {
            string serializedData = data.Serialize();
            
            if (_serializableState.TryAdd(key.Value, serializedData) == false)
            {
                _serializableState[key.Value] = serializedData;
            }
        }

        public bool TryGetData<T>(ISerializableKey key, out T result) where T : ISerializable, new()
        {
            if(_serializableState.TryGetValue(key.Value, out string data) == true)
            {
                result = JsonConvert.DeserializeObject<T>(data);
                return true;
            }

            result = default;
            return false;
        }


        public void SerializeState()
        {
            string stateJson = JsonConvert.SerializeObject(_serializableState);
            PlayerPrefs.SetString(STATE_PATH, stateJson);
        }

        public void DeserializeState()
        {
            if(_serializableState.Count != 0) return;
            
            if (PlayerPrefs.HasKey(STATE_PATH) == true)
            {
                string data = PlayerPrefs.GetString(STATE_PATH);
                _serializableState = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
            }
        }

        public void Clear()
        {
            if (PlayerPrefs.HasKey(STATE_PATH) == true)
            {
                PlayerPrefs.DeleteKey(STATE_PATH);
            }
        }
    }
}