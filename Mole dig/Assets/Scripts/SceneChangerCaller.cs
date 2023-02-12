using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangerCaller : MonoBehaviour
{
    public void Call(string sceneName)
    {
        SceneChanger.Instance().ChangeScene(sceneName);
    }
}
