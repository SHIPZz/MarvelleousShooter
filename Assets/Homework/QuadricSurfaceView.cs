using System;
using UnityEngine;
using UnityEngine.UI;

public class QuadricSurfaceView : MonoBehaviour
{
    public InputField A;
    public InputField B;
    public InputField C;

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