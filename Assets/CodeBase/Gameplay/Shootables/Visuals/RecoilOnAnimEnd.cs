using CodeBase.Gameplay.Shootables.Recoils;
using UnityEngine;

namespace CodeBase.Gameplay.Shootables.Visuals
{
    public class RecoilOnAnimEnd : MonoBehaviour
    {
        [SerializeField] private Recoil _recoil;

        public void Recoil() => _recoil.GenerateRecoil();
    }
}