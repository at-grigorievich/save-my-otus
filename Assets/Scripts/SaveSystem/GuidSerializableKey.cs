using System;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace SaveSystem
{
    [CreateAssetMenu(menuName = "SaveSystem/Create Key", fileName = "serialize-key")]
    public class GuidSerializableKey: ScriptableObject
    {
        [field: SerializeField, ReadOnly] public string Value { get; private set; }

        private void Reset()
        {
            Value = Guid.NewGuid().ToString();
            
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}