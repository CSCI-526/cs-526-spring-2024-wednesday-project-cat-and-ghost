using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWinTrigger : MonoBehaviour
{
    public Transform target; // 目标对象的Transform组件
    private NewBehaviourScript targetScript;
    public bool isTutorial;

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
            CustomEvent myEvent = new CustomEvent("WinCheckPoint") {
                    {"GameLevel", "Level 3"}
                };
            AnalyticsService.Instance.RecordEvent(myEvent);
            AnalyticsService.Instance.Flush();
        }
    }

    // 游戏结束逻辑
    private void YouWin() {
        // 加载一个游戏结束场景
        SceneManager.LoadScene("YouWinScene");
    }
}
