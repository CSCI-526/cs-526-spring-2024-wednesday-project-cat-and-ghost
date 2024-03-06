using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgainScrene() {

        Time.timeScale = 1f; // Make sure to reset the time scale, or the game will remain paused
        //SceneManager.LoadScene(sceneName);

        // 使用 GameData 中存储的 index 值重新加载场景
        //string levelSceneName = "Level" + GameData.currentLevelIndex.ToString();
        // 重新加载当前关卡
        SceneManager.LoadScene(GameData.scnenName);
    }
}
