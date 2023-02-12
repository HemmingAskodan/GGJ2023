using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerInvoker : MonoBehaviour
{
    public UnityEvent unityEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            unityEvent.Invoke();
        }
    }
}
