using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackground : MonoBehaviour
{
    [SerializeField] private Color whiteBG;
    [SerializeField] private Color blackBG;

    public void OnWorldSwap(bool type) {
        if (Camera.main) Camera.main.backgroundColor = type ? blackBG : whiteBG;
    }

}
