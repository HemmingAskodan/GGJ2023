using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAnimationEvents : MonoBehaviour
{
    public AudioSource source;
    // Start is called before the first frame update
    public void invoke()
    {
        source.Play();
    }
}
