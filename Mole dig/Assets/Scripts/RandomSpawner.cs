using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public struct SpawnObject{
    public GameObject prefab;
    public int amount;
}


public class RandomSpawner : MonoBehaviour
{

    public Vector2 areaTopLeft;
    public Vector2 areaBottomRight;
    public SpawnObject[] spawnObjects;

    // Start is called before the first frame update
    private void Awake() {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
