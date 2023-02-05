using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventInvoker : MonoBehaviour
{
    int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public UnityEvent[] unityEvent;
    public void Invoke(){
        if(index >= unityEvent.Length)
        {
            index = 0;
        }
        unityEvent[index++].Invoke();
    }
}
