using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Common.Services.BehaviourTreeInjection
{
    public class BehaviourTreeInjector : MonoBehaviour
    {
        private DiContainer _diContainer;
        private Behavior _tree;

        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
            _tree = GetComponent<Behavior>();
            _tree.enabled = false;
            Inject(_tree);
        }

        public void Inject(Behavior behavior)
        {
            var tasks = behavior.FindTasks<Task>();

            if (tasks == null)
                return;

            foreach (Task task in tasks) 
                _diContainer.Inject(task);

            _tree.enabled = true;
        }
    }
}