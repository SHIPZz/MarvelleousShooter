using System.Collections;
using UnityEngine;

namespace CodeBase.InfraStructure.AssetManagement_1
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator load);
    }
}