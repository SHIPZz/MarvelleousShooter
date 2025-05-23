﻿using System.Collections;
using UnityEngine;

namespace Code.InfraStructure.AssetManagement_1
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator load);
    }
}