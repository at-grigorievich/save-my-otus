using System;
using System.Collections.Generic;
using SaveSystem;
using UnityEngine;

namespace GameEngine.Save
{
    public struct UnitSerializableData: ISerializable
    {
        public Vector3 Position;
        public Vector3 Rotation;

        public UnitSerializableData(Unit unit)
        {
            Position = unit.Position;
            Rotation = unit.Rotation;
        }
        
        public string Serialize()
        {
            return JsonUtility.ToJson(this);
        }
    }
    
    public class UnitsSaveLoader: ISaveLoader
    {
        private readonly UnitManager _unitManager;
        private readonly ISerializableRepository _serializableRepository;

        private readonly Dictionary<Unit, ISerializableKey> _cachedKeys = new();

        public UnitsSaveLoader(ISerializableRepository repository, UnitManager unitManager)
        {
            _unitManager = unitManager;
            _serializableRepository = repository;
        }
        
        public void Save()
        {
            foreach (var unit in _unitManager.GetAllUnits())
            {
                if (_cachedKeys.TryGetValue(unit, out var key) == false)
                {
                    if (unit.TryGetComponent(out key) == false)
                    {
                        throw new NullReferenceException("Unit does not contain a component of type " + typeof(ISerializableKey));
                    }
                    
                    _cachedKeys.Add(unit, key);
                }
                
                ISerializable data = new UnitSerializableData(unit);
                
                _serializableRepository.SetData(key, data);
            }
            
            Debug.Log("units serialized");
        }

        public void Load()
        {
            foreach (var unit in _unitManager.GetAllUnits())
            {
                ISerializableKey key;
                
                if (_cachedKeys.TryGetValue(unit, out key) == false)
                {
                    if (unit.TryGetComponent(out key) == false)
                    {
                        throw new NullReferenceException("Unit does not contain a component of type " + typeof(ISerializableKey));
                    }
                    
                    _cachedKeys.Add(unit, key);
                }

                if (_serializableRepository.TryGetData(key, out UnitSerializableData data) == true)
                {
                    unit.transform.position = data.Position;
                    unit.transform.rotation = Quaternion.Euler(data.Rotation);
                }
            }
            
            Debug.Log("units deserialized");
        }
    }
}