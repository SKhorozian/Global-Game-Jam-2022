using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WorldTypeSwitcher : MonoBehaviour
{
    public UnityEvent<bool> OnWorldSwap;
    
    private bool _worldType = false; //Black true | White false
    public bool WorldType => _worldType;
    public void SwapWorld() {
        _worldType = !_worldType;
        
        OnWorldSwap?.Invoke(_worldType);   
    }

    private static WorldTypeSwitcher _instance;

    public static WorldTypeSwitcher Instance {
        get {
            if (_instance) return _instance;

            _instance = FindObjectOfType<WorldTypeSwitcher>();
            
            if (!_instance) Debug.LogError("Singleton of type [WorldType] not found");
            
            return _instance;
        }
    }

}
