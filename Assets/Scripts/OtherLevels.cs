using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OtherLevels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenLevelSelector()
    {
        //跳转scene
        Time.timeScale = 1; // 游戏继续
        SceneManager.LoadScene("LevelSelect");

    }
}
