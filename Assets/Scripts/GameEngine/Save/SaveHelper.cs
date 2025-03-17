using SaveSystem;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace GameEngine.Save
{
    public sealed class SaveHelper : MonoBehaviour
    {
        [Inject] private ISaveLoader _saveLoader;

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
    }
}