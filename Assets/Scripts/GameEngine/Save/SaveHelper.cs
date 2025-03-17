using SaveSystem;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace GameEngine.Save
{
    public sealed class SaveHelper : MonoBehaviour
    {
        [Inject] private ISaveLoaderFacade _saveLoader;
        [Inject] private ISerializeRepositoryClearable _serializeRepositoryClearing;

        [Button]
        public void Save()
        {
#if UNITY_EDITOR
            _saveLoader.Save();
#endif
        }

        [Button]
        public void Load()
        {
#if UNITY_EDITOR
            _saveLoader.Load();
#endif
        }

        [Button]
        public void Clear()
        {
#if UNITY_EDITOR
                _serializeRepositoryClearing.Clear();
                Debug.Log("serialize repository cleared");
#endif
        }
    }
}