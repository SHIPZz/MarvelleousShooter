using Code.UI;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.LevelDatas
{
    public class UIInitializer : MonoBehaviour, IInitializable
    {
        public Canvas MainUI;
        
        [Inject] private IUIProvider _uiProvider;
        
        public void Initialize()
        {
            _uiProvider.MainUI = MainUI;
        }
    }
}