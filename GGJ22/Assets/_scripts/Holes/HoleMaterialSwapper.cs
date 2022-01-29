using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleMaterialSwapper : MonoBehaviour
{
    [SerializeField] private MeshRenderer _renderer;

    [SerializeField] private Material black;
    [SerializeField] private Material white;
    
    private void Start() {
        if (!_renderer) _renderer = GetComponent<MeshRenderer>();
        
        WorldTypeSwitcher.Instance.OnWorldSwap.AddListener(OnWorldSwap);
    }

    private void OnWorldSwap(bool type) {
        _renderer.material = type ? white : black;
    }
}
