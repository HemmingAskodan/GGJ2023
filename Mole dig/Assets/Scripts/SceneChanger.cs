using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    private static SceneChanger instance;
    public static SceneChanger Instance()
    {
        return instance;
    }
    public Image fadeImage;
    public float fadeTime = .2f;

    // Start is called before the first frame update
    void Awake()
    {
        // Color c = fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1);

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        Color fc = fadeImage.color;
        fadeImage.color = new Color(fc.r, fc.g, fc.b, fc.a + ((fadeOut ? 1 : -1) * Time.deltaTime / fadeTime));
    }

    private string sceneName;
    private bool fadeOut = false;

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        fadeOut = true;

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        fadeOut = false;
    }
    // IEnumerator DelayLoad()
    // {
    //     yield return new WaitForSeconds(fadeTime);
    //     SceneManager.LoadScene(sceneName);
    // }
    public void ChangeScene(string sceneName)
    {
        this.sceneName = sceneName;
        fadeOut = true;
        StartCoroutine(LoadYourAsyncScene());
    }
}
