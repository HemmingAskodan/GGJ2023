using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DeathCodes{
    Explode,
    StaminaDrain
}

public class DeathCodeController : MonoBehaviour
{
    public Animator moleSpriteAnimator;

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
