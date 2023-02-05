using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    private static SceneChanger instance;
    public static SceneChanger Instance(){
        return instance;
    }
    public Image fadeImage;
    public float fadeTime = 1f;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update() {
        Color fc = fadeImage.color;
        fc = new Color(fc.r,fc.g,fc.b,fc.a + ((fadeOut?1:-1)*Time.deltaTime/fadeTime));
    }

    private string sceneName;
    private bool fadeOut = false;

    IEnumerator DelayLoad()
    {
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(sceneName);
    }
    public void ChangeScene(string sceneName)
    {
        this.sceneName = sceneName;
        fadeOut = true;
        StartCoroutine(DelayLoad());
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
        fadeOut = false;
    }
}
