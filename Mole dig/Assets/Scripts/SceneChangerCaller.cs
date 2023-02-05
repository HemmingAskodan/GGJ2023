using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangerCaller : MonoBehaviour
{
    public string sceneName;

    public void Call()
    {
        SceneChanger.Instance().ChangeScene(sceneName);
    }
}
