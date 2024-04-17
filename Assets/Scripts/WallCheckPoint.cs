using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;
using Unity.Services.Core;
using Unity.Services.Core.Analytics;
using UnityEngine.Analytics;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using Proyecto26; // 引用Proyecto26库
using System;

//[System.Serializable]
//public class CheckPointData
//{
//    public string levelName;
//    public string checkedDateTime;
//    public string Checkpoint;
//    public string gameStatus;
//}
public class WallCheckPoint : MonoBehaviour
{
    private bool hasTriggered = false; // 记录玩家是否走过当前checkpoint的flag
    private string firebaseUrl = "https://csci526-catandghost-default-rtdb.firebaseio.com/"; // 你的Firebase URL
    // Start is called before the first frame update
    async void Start()
    {
        try
        {
            Debug.Log("初始化");
            await UnityServices.InitializeAsync();
            GiveConsent(); // Get user consent according to various legislations
        }
        catch (ConsentCheckException e)
        {
            Debug.Log(e.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GiveConsent()
    {
        // Call if consent has been given by the user
        AnalyticsService.Instance.StartDataCollection();
        Debug.Log($"Consent has been provided. The SDK is now collecting data!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("进入碰撞区");
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true; // Prevent further triggers
            //CustomEvent myEvent = new CustomEvent("WallCheckPoint")
            //{
            //    {"CheckpointName", gameObject.tag},
            //    {"GameLevel", "Level 3"}
            //};

            GameData.checkPointdata = new CheckPointData
            {
                levelName = SceneManager.GetActiveScene().name,
                checkedDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Checkpoint = gameObject.tag,
                gameStatus = ""
            };
            ////};

            // 转换对象为JSON
            //string jsonData = JsonUtility.ToJson(checkPointdata);

            //// 使用Proyecto26上传数据
            //RestClient.Post($"{firebaseUrl}CheckpointData.json", jsonData).Then(response => {
            //    Debug.Log("CheckpointData data uploaded successfully!");
            //}).Catch(error => {
            //    Debug.LogError($"Failed to upload win data: {error}");
            //});

            //AnalyticsService.Instance.RecordEvent(myEvent);
            //AnalyticsService.Instance.Flush();
            // Trigger the "levelStart" event with the current level as a parameter
            Debug.Log("路线" + gameObject.tag);
        }
    }
}