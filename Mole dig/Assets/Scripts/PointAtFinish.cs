using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAtFinish : MonoBehaviour
{
    private Transform finishT;
    // Start is called before the first frame update
    void Start()
    {
        finishT = GameObject.FindGameObjectWithTag("Finish").transform;
        print(finishT);

        Vector2 direction = finishT.position - transform.position;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90);
    }
}
