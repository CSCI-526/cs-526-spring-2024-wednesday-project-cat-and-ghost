using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using Proyecto26;

[System.Serializable]
public class WinData
{
    public string levelName;
    public string winDateTime;
    public double durationSeconds;
}
public class YouWinTrigger : MonoBehaviour
{
    public Transform target; // 目标对象的Transform组件
    private NewBehaviourScript targetScript;
    public bool isTutorial;
    private string firebaseUrl = "https://csci526-catandghost-default-rtdb.firebaseio.com/"; // 你的Firebase URL

    // Start is called before the first frame update
    void Start()
    {
        targetScript = target.GetComponent<NewBehaviourScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // 检查触发器碰撞的对象是否为玩家
        if (other.gameObject == target.gameObject) {
            if (isTutorial) {
                SceneManager.LoadScene("TutorialWinScene");
            } else {
                YouWin();
            }
            //YouWin();
            //记录本轮游戏结束
            //CustomEvent myEvent = new CustomEvent("WinCheckPoint") {
            //        {"GameLevel", "Level 3"}
            //    };
            //AnalyticsService.Instance.RecordEvent(myEvent);
            //AnalyticsService.Instance.Flush();

            // 转换对象为JSON
            GameData.checkPointdata.gameStatus = "Win";
            string jsonData = JsonUtility.ToJson(GameData.checkPointdata);

            // 使用Proyecto26上传数据
            RestClient.Post($"{firebaseUrl}CheckpointData.json", jsonData).Then(response =>
            {
                Debug.Log("CheckpointData data uploaded successfully!");
            }).Catch(error =>
            {
                Debug.LogError($"Failed to upload win data: {error}");
            });
        }
    }

    // 游戏结束逻辑
    private void YouWin()
    {
        TimeSpan duration = DateTime.Now.Subtract(targetScript.startTime);
        // 加载一个游戏结束场景
        SceneManager.LoadScene("YouWinScene");
        // 创建WinData对象
        WinData winData = new WinData
        {
            levelName = SceneManager.GetActiveScene().name,
            winDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            durationSeconds = duration.TotalSeconds
        };

        // 转换对象为JSON
        string jsonData = JsonUtility.ToJson(winData);

        // 使用Proyecto26上传数据
        RestClient.Post($"{firebaseUrl}winData.json", jsonData).Then(response => {
            Debug.Log("Win data uploaded successfully!");
        }).Catch(error => {
            Debug.LogError($"Failed to upload win data: {error}");
        });
    }
}
