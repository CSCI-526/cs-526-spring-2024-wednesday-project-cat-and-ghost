using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour
{
    public string SceneName;

    public void LoadSceneByName() {
        //跳转scene
        SceneManager.LoadScene(SceneName);
    }
}
