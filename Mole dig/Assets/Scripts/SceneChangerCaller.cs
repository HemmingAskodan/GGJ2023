using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangerCaller : MonoBehaviour
{
    public void Call(string sceneName)
    {
        print("Call");
        SceneChanger.Instance().ChangeScene(sceneName);
    }
}
