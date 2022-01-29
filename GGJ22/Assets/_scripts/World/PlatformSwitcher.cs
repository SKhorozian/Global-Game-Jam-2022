using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject whitePlatforms;
    [SerializeField] private GameObject blackPlatforms;

    public void OnWorldSwitch(bool type) {
        whitePlatforms.SetActive(!type);
        blackPlatforms.SetActive(type);
    }
}
