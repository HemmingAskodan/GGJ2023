using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MineTriggered : MonoBehaviour
{
    public SpriteRenderer mineSprite;
    public AnimationCurve distanceCurve;
    private Transform playerTransform;

    void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerTransform = player.transform;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Kill player
            DeathCodeController deathCodeController = other.GetComponent<DeathCodeController>();
            if (deathCodeController != null)
            {
                deathCodeController.killMole(DeathCodes.Explode);
            }

            // Play explotion
            Animator animator = mineSprite.gameObject.GetComponent<Animator>();
            animator.SetTrigger("Explode");
        }
    }

    private void LateUpdate()
    {
        float playerDept = playerTransform.position.y;
        float distanceVary = CustomProperties.Instance.deptUntilFullyDark + playerDept;

        float dist01 = distanceCurve.Evaluate(Vector3.Distance(transform.position, playerTransform.position) / Mathf.Max(0, distanceVary));
        Color currColor = mineSprite.color;
        mineSprite.color = new Color(currColor.r, currColor.g, currColor.b, 1 - dist01);
    }

    private void OnDisable()
    {
        Color currColor = mineSprite.color;
        mineSprite.color = new Color(currColor.r, currColor.g, currColor.b, 1);
    }
}
