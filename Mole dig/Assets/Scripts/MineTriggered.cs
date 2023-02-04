using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MineTriggered : MonoBehaviour
{
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
}
