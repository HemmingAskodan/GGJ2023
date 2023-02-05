using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public static GameOverScreen Instance{get; private set;}

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

    public void Show(bool show)
    {
        gameObject.GetComponent<Canvas>().enabled = show;
    }
}
