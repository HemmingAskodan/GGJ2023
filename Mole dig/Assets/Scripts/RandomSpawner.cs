using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft;

[System.Serializable]
public struct SpawnObject
{
    public GameObject prefab;
    public int amount;
}


public class RandomSpawner : MonoBehaviour
{

    public Vector2 areaTopLeft;
    public Vector2 areaBottomRight;
    public SpawnObject[] spawnObjects;

    // Start is called before the first frame update
    private void Awake()
    {
        foreach (SpawnObject spawnObject in spawnObjects)
        {
            Collider2D collider2D = spawnObject.prefab.GetComponent<Collider2D>();
            string colliderType = collider2D.GetType().ToString();
            for (int i = 0; i < spawnObject.amount; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    Vector2 randomPosition = new Vector2(
                        Random.Range(areaTopLeft.x, areaBottomRight.x),
                        Random.Range(areaTopLeft.y, areaBottomRight.y)
                    );

                    bool spawn = false;
                    switch(colliderType)
                    {
                        case "UnityEngine.CircleCollider2D":
                            CircleCollider2D realCollider2D = spawnObject.prefab.GetComponent<CircleCollider2D>();
                            if(!Physics2D.OverlapCircle(randomPosition,realCollider2D.radius))
                            {
                                spawn = true;
                                break;
                            }
                        break;
                        default:
                            spawn = true;
                        break;
                    }

                    if(spawn == true)
                    {
                        Instantiate(spawnObject.prefab,
                            randomPosition,
                            Quaternion.Euler(0, 0, Random.Range(0, 360f))
                        );
                        break;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
