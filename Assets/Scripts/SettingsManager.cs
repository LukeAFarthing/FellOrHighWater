using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static bool isHardMode;
    public static bool isRedMode;

    public void SetHardMode(bool hardMode)
    {
        //Debug.Log(hardMode);
        isHardMode = hardMode;
    }

    public void SetRedMode(bool redMode)
    {
        //Debug.Log(redMode);
        isRedMode = redMode;
    }
}
