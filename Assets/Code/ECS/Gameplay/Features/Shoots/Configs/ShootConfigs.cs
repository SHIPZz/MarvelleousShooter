using System;
using System.Collections.Generic;
using Code.ECS.Gameplay.Features.Shoots.Enums;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEditor;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots.Configs
{
    [CreateAssetMenu(fileName = "ShootConfigs", menuName = "Gameplay/ShootConfigs")]
    public class ShootConfigs : SerializedScriptableObject
    {
        [OdinSerialize] private Dictionary<GunTypeId, ShootConfig> _shootConfigs;
        

        public ShootConfig GetById(GunTypeId gunTypeId)
        {
            return _shootConfigs.TryGetValue(gunTypeId, out var result) ? result : throw new ArgumentException($"No such config for {gunTypeId}");
        }
        
        
        [Button("Update Configs From Folder")]
        public void UpdateConfigsFromFolder()
        {
            if (_shootConfigs == null)
            {
                _shootConfigs = new Dictionary<GunTypeId, ShootConfig>();
            }

            string currentPath = AssetDatabase.GetAssetPath(this);
            string directory = System.IO.Path.GetDirectoryName(currentPath);

            string[] guids = AssetDatabase.FindAssets("t:ShootConfig", new[] { directory });
    
            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                ShootConfig config = AssetDatabase.LoadAssetAtPath<ShootConfig>(path);
        
                if (config != null) 
                {
                    if (_shootConfigs.TryAdd(config.gunTypeId, config))
                    {
                        Debug.Log($"Added new config: {config.gunTypeId} from {path}");
                    }
                }
            }

            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
        }

    }
}
