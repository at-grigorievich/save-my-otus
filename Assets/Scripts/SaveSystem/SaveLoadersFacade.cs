using System.Collections.Generic;

namespace SaveSystem
{
    public class SaveLoadersFacade: ISaveLoaderFacade
    {
        private readonly IEnumerable<ISaveLoader> _saveLoaders;
        private readonly ISerializableRepository _serializableRepository;

        public SaveLoadersFacade(ISerializableRepository repository, IEnumerable<ISaveLoader> saveLoaders)
        {
            _saveLoaders = saveLoaders;
            _serializableRepository = repository;
        }
        
        public void Save()
        {
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.Save();
            }
            
            _serializableRepository.SerializeState();
        }

        public void Load()
        {
            _serializableRepository.DeserializeState();
            
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.Load();
            }
        }
    }
}