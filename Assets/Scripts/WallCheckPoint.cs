using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;
using Unity.Services.Core;
using Unity.Services.Core.Analytics;
using UnityEngine.Analytics;
using System.Threading.Tasks;

public class WallCheckPoint : MonoBehaviour
{
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
        if (other.CompareTag("Player"))
        {
            CustomEvent myEvent = new CustomEvent("WallCheckPoint")
            {
                {"CheckpointName", gameObject.tag},
                {"GameLevel", "Level 3"}
            };
            AnalyticsService.Instance.RecordEvent(myEvent);
            AnalyticsService.Instance.Flush();
            // Trigger the "levelStart" event with the current level as a parameter
            Debug.Log("路线" + gameObject.tag);
        }
    }
}