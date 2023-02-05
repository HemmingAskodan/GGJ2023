using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeepSoundIntervalByPlayer : MonoBehaviour
{
    private Transform playerTransform;
    public AudioSource beepSound;
    public float closestAway = 1;
    public float furthestAway = 3.5f;
    public float fastestInterval = 1;
    private float currentInterval;
    public AnimationCurve distCurve;
    void Awake() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        if(player != null)
        {
            playerTransform = player.transform;
        }

        currentInterval = fastestInterval;
    }

    // Update is called once per frame
    void Update()
    {
        float dist01 = 1-((Mathf.Clamp(Vector2.Distance(playerTransform.position,transform.position),closestAway,furthestAway) - closestAway) / (furthestAway - closestAway));
        dist01 = distCurve.Evaluate(dist01);

        currentInterval -= Time.deltaTime * (dist01);
        if(currentInterval < 0)
        {
            currentInterval += fastestInterval;
            beepSound.volume = dist01;
            beepSound.Play();
        }
    }
}
