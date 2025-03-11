// Animancer // https://kybernetik.com.au/animancer // Copyright 2018-2025 Kybernetik //

#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value.

using UnityEngine;

namespace Animancer.Samples.FineControl
{
    /// <summary>
    /// An <see cref="IInteractable"/> door which toggles between open and closed when something interacts with it.
    /// </summary>
    /// 
    /// <remarks>
    /// <strong>Sample:</strong>
    /// <see href="https://kybernetik.com.au/animancer/docs/samples/fine-control/doors">
    /// Doors</see>
    /// </remarks>
    /// 
    /// https://kybernetik.com.au/animancer/api/Animancer.Samples.FineControl/Door
    /// 
    [AddComponentMenu(Strings.SamplesMenuPrefix + "Fine Control - Door")]
    [AnimancerHelpUrl(typeof(Door))]
    [SelectionBase]
    public class Door : MonoBehaviour, IInteractable
    {
        /************************************************************************************************************************/

        [SerializeField] private SoloAnimation _SoloAnimation;

        /************************************************************************************************************************/

        /// <summary>[<see cref="IInteractable"/>] Toggles this door between open and closed.</summary>
        public void Interact()
        {
            if (_SoloAnimation.Speed == 0)
            {
                bool playForwards = _SoloAnimation.NormalizedTime < 0.5f;
                Debug.Log($"@@@ speed {_SoloAnimation.NormalizedTime} - 1");
                _SoloAnimation.Speed = playForwards ? 1 : -1;
                Debug.Log($"@@@ speed {_SoloAnimation.Speed} - 2");
            }
            else
            {
                _SoloAnimation.Speed = -_SoloAnimation.Speed;
            }

            _SoloAnimation.IsPlaying = true;
        }

        /************************************************************************************************************************/
    }
}
