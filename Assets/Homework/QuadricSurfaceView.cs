using System;
using TMPro;
using UnityEngine;

public class QuadricSurfaceView : MonoBehaviour
{
    public TMP_InputField A;
    public TMP_InputField B;
    public TMP_InputField C;

    public DynamicQuadricSurface Surface;

    private void Start()
    {
        A.onValueChanged.AddListener(value => TryUpdateSurfaceValue(value, ref Surface.A));
        B.onValueChanged.AddListener(value => TryUpdateSurfaceValue(value, ref Surface.B));
        C.onValueChanged.AddListener(value => TryUpdateSurfaceValue(value, ref Surface.C));
    }

    private void TryUpdateSurfaceValue(string value, ref float field)
    {
        if (float.TryParse(value, out float result))
        {
            field = result;
        }
        else
        {
            Debug.LogWarning("Invalid input, not a valid integer.");
        }
    }
}