using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    public Image staminaBar;
    public float distanceTraveledUntilCompletelyDrained = 30f;
    public static StaminaController Instance{get; private set;}

    // Start is called before the first frame update
    private void Awake() {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void OnDestroy() {
        Instance = null;
    }

    public void AddOnStamina(float value)
    {
        staminaBar.fillAmount += value/distanceTraveledUntilCompletelyDrained;
    }
    public void AddOnStaminaPercent(float percent)
    {
        staminaBar.fillAmount += percent/100f;
    }
}
