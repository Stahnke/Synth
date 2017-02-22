using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MFConverter
{

    public static float mtof(int m)
    {
        return 440.0f * Mathf.Pow(2, (m - 69.0f) / 12.0f);
    }

    public static int ftom(float f)
    {
        return Mathf.RoundToInt(69.0f + 12.0f * Mathf.Log( (f/440.0f), 2.0f));
    }
}
