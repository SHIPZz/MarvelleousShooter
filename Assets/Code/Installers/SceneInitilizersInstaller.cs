using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class SceneInitializationInstaller : MonoInstaller
    {
        public List<MonoBehaviour> Initializables;

        public override void InstallBindings()
        {
            foreach (MonoBehaviour initializable in Initializables)
            {
                Container.BindInterfacesTo(initializable.GetType())
                    .FromInstance(initializable).AsSingle();
            }
        }
    }
}