using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePausedScript : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            TogglePause();
        }
    }

    void TogglePause() {
        isPaused = !isPaused;
        if (isPaused) {
            Time.timeScale = 0; // 游戏暂停
            pauseMenuCanvas.SetActive(true); // 显示Canvas
        } else {
            Time.timeScale = 1; // 游戏继续
            pauseMenuCanvas.SetActive(false); // 隐藏Canvas
        }
    }
}
