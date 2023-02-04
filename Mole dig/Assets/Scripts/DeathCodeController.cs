using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DeathCodes{
    Explode,
    StaminaDrain
}

[RequireComponent(typeof(Animator))]
public class DeathCodeController : MonoBehaviour
{
    Animator animator => GetComponent<Animator>();

    public void killMole(DeathCodes deathCode){
        if(deathCode == DeathCodes.Explode)
        {
            // Play death on explosion
            gameObject.SetActive(false);
        }
        if(deathCode == DeathCodes.StaminaDrain)
        {

        }
    }
}
