using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DeathCodes
{
    Explode,
    StaminaDrain
}

public class DeathCodeController : MonoBehaviour
{
    public Animator moleSpriteAnimator;

    IEnumerator DelayShowGameOver()
    {
        yield return new WaitForSeconds(3);
        GameOverScreen.Instance.Show(true);
    }
    public void killMole(DeathCodes deathCode)
    {
        bool isDead = false;
        if (deathCode == DeathCodes.Explode)
        {
            // Play death on explosion
            gameObject.SetActive(false);
            isDead = true;
        }
        if (deathCode == DeathCodes.StaminaDrain)
        {
            moleSpriteAnimator.SetTrigger("Stamina Drain");
            GetComponent<PlayerController>().enabled = false;
            isDead = true;
        }
        if (isDead)
        {
            // StartCoroutine(DelayShowGameOver());
            GameOverScreen.Instance.Show(true);
            foreach (MineTriggered mineTriggered in Resources.FindObjectsOfTypeAll(typeof(MineTriggered)))
            {
                mineTriggered.ShowMine();
            }
        }
    }
}
