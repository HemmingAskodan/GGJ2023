using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class MineTriggered : MonoBehaviour
{
    SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();
    public AnimationCurve distanceCurve;
    private Transform playerTransform => GameObject.FindGameObjectWithTag("Player").transform;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Kill player
            DeathCodeController deathCodeController = other.GetComponent<DeathCodeController>();
            if(deathCodeController != null)
            {
                deathCodeController.killMole(DeathCodes.Explode);
            }

            // Play explotion
            gameObject.SetActive(false);
        }
    }

    private void LateUpdate() {

        float playerDept = playerTransform.position.y;
        float distanceVary = CustomProperties.Instance.deptUntilFullyDark + playerDept;
        
        float dist01 = distanceCurve.Evaluate(Vector3.Distance(transform.position,playerTransform.position)/distanceVary);
        print(dist01);
        Color currColor = spriteRenderer.color;
        spriteRenderer.color = new Color(currColor.r,currColor.g,currColor.b,1-dist01);
    }
}
