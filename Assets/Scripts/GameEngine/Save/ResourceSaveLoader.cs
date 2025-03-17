using SaveSystem;
using UnityEngine;

namespace GameEngine.Save
{
    public struct ResourceSerializableData: ISerializable
    {
        public int Amount;
        
        public ResourceSerializableData(Resource resource)
        {
            Amount = resource.Amount;
        }
        
        public string Serialize()
        {
            return JsonUtility.ToJson(this);
        }
    }
    
    public class ResourceSaveLoader: ISaveLoader
    {
        private readonly ResourceService _resourceService;
        private readonly ISerializableRepository _serializableRepository;

        public ResourceSaveLoader(ResourceService resourceService, ISerializableRepository serializableRepository)
        {
            _resourceService = resourceService;
            _serializableRepository = serializableRepository;
        }
        
        public void Save()
        {
            foreach (var resource in _resourceService.GetResources())
            {
                ResourceSerializableData data = new ResourceSerializableData(resource);
                _serializableRepository.SetData(StringSerializableKey.Create(resource.ID), data);
            }
            Debug.Log("resources serialized");
        }

        public void Load()
        {
            foreach (var resource in _resourceService.GetResources())
            {
                if (_serializableRepository.TryGetData(StringSerializableKey.Create(resource.ID), 
                        out ResourceSerializableData data) == true)
                {
                    resource.Setup(data);
                }
            }
            Debug.Log("resources deserialized");
        }
    }
}