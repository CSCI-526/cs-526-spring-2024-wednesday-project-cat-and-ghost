using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public int level;

    public void OpenScene()
    {
        StartCoroutine(LoadYourAsyncScene());
    }

    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level" + level.ToString());

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // 这里可以添加场景加载完成后的代码，比如重置玩家状态等
    }


    public void LoadNewScene(string sceneName) {
        // 加载新场景
        SceneManager.LoadScene(sceneName);
    }
}

