using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChangeBasedOnPlayer : MonoBehaviour
{
    private Transform playerTransform;
    public SpriteRenderer spriteRenderer;
    public AnimationCurve distanceCurve = AnimationCurve.Linear(0,0,1,1);
    void Awake() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        if(player != null)
        {
            playerTransform = player.transform;
        }
    }
    void LateUpdate()
    {
        float playerDept = playerTransform.position.y;

        float deptUntilFullyDark = CustomProperties.Instance.deptUntilFullyDark;
        
        float dist01 = (Mathf.Clamp(distanceCurve.Evaluate((25 + playerDept)/25),CustomProperties.Instance.darkestValue,1));
        Color currColor = spriteRenderer.color;
        spriteRenderer.color = new Color(dist01,dist01,dist01,currColor.a);
    }
}
