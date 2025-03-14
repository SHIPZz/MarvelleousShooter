using System;

namespace Code.InfraStructure.Loading
{
    public interface ISceneLoader
    {
        void LoadScene(string name, Action onLoaded = null);
    }
}