using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomProperties : MonoBehaviour
{
    public static CustomProperties Instance{get; private set;}
    public float deptUntilFullyDark = 25f;
    public float darkestValue = 0.5f;

    // Start is called before the first frame update
    private void Awake() {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnDestroy() {
        Instance = null;
    }
}
