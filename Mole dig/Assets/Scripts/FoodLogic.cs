using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FoodLogic : MonoBehaviour
{
    public Sprite[] spriteVariants;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        int randomSpriteIndex = Random.Range(0,spriteVariants.Length);
        spriteRenderer.sprite = spriteVariants[randomSpriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //YUM
            gameObject.SetActive(false);
            StaminaController.Instance.AddOnStaminaPercent(5);
        }
    }
}
