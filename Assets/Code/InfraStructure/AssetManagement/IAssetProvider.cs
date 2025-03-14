using UnityEngine;

namespace Code.InfraStructure.AssetManagement
{
    public interface IAssetProvider
    {
        GameObject LoadAsset(string path);
        T LoadAsset<T>(string path) where T : Component;
        T[] LoadAllAssets<T>(string path) where T : Component;
    }
}