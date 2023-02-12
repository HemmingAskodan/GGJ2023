using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[System.Serializable]
public class AudioDependentOnPlayerDeptSettings
{
    public AudioSource audioSource;
    public float transitionTime = 4f;
    public float playUnderTheDeptOf = 5f;
    [Range(0, 1)]
    public float maxVolume = 1;
    // public AnimationCurve transitionCurve;
    [HideInInspector]
    public float volumeInWhichTransitionStarted;
}

public class AudioPlayDependentOnPlayerDept : MonoBehaviour
{
    private Transform playerTransform;
    private AudioDependentOnPlayerDeptSettings audioToPlay;
    private int audioIndexToPlay;
    public AudioDependentOnPlayerDeptSettings[] audioDependentOnPlayerDeptSettings;
    private float transitionStarted;
    private float transitionTime;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float playerDept = playerTransform.position.y;

        float closest = -999999f;
        int currentIndexPlaying = audioIndexToPlay;
        for (int i = 0; i < audioDependentOnPlayerDeptSettings.Length; i++)
        {
            AudioDependentOnPlayerDeptSettings adopds = audioDependentOnPlayerDeptSettings[i];
            float playVsDept = playerDept - adopds.playUnderTheDeptOf;
            if (playVsDept < 0 && playVsDept > closest)
            {
                closest = playVsDept;
                audioToPlay = adopds;
                audioIndexToPlay = i;
            }
        }

        if (currentIndexPlaying != audioIndexToPlay)
        {
            transitionTime = audioToPlay.transitionTime;
            transitionStarted = Time.time;

            for (int i = 0; i < audioDependentOnPlayerDeptSettings.Length; i++)
            {
                audioDependentOnPlayerDeptSettings[i].volumeInWhichTransitionStarted = audioDependentOnPlayerDeptSettings[i].audioSource.volume;
            }
        }

        for (int i = 0; i < audioDependentOnPlayerDeptSettings.Length; i++)
        {
            AudioSource audioSource = audioDependentOnPlayerDeptSettings[i].audioSource;
            if (Time.time < transitionStarted + transitionTime)
            {
                if (i == audioIndexToPlay)
                {
                    float currentVolume = audioSource.volume;
                    float maxVolume = audioDependentOnPlayerDeptSettings[i].maxVolume;
                    audioSource.volume = Mathf.Min(currentVolume + (Time.deltaTime / transitionTime) * audioDependentOnPlayerDeptSettings[i].maxVolume, maxVolume);
                }
                else
                {
                    audioSource.volume -= (Time.deltaTime / transitionTime) * audioDependentOnPlayerDeptSettings[i].volumeInWhichTransitionStarted;
                }
            }
            else
            {
                if (i == audioIndexToPlay)
                {
                    audioSource.volume = audioDependentOnPlayerDeptSettings[i].maxVolume;
                }
                else
                {
                    audioSource.volume = 0;
                }
            }
        }
    }
    // private void LateUpdate() {
    //     float playerDept = playerTransform.position.y;

    //     float deptUntilFullyDark = CustomProperties.Instance.deptUntilFullyDark;

    //     float dist01 = distanceCurve.Evaluate((25 + playerDept)/25),CustomProperties.Instance.darkestValue,1));
    //     Color currColor = spriteRenderer.color;
    //     spriteRenderer.color = new Color(dist01,dist01,dist01,currColor.a);
    // }
}
