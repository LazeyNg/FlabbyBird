using UnityEngine;
using SatorImaging.AppWindowUtility;

#if UNITY_EDITOR
using static UnityEditor.Experimental.GraphView.Port;
#endif

public class TransparentWin : MonoBehaviour
{
    void Start()
    {
        AppWindowUtility.Transparent = true;
        //AppWindowUtility.SetWindowOpacity(75);
    }
}