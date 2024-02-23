using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NailDeath : MonoBehaviour
{
    public GameObject Player;
    public GameObject Ghost;
    private Renderer nailRender;
    public Color32 curNailColor; // 当前nail的颜色

    public Transform target; // 目标对象的Transform组件
    private NewBehaviourScript targetScript;

    // Start is called before the first frame update
    void Start()
    {
        targetScript = target.GetComponent<NewBehaviourScript>();
        nailRender = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")|| other.gameObject == Player)
        {
            //判断钉子和背景颜色是否一样,如果不一样则可以碰撞
            //钉子和玩家颜色不一样可以碰撞
            if (!targetScript.bgColor.Equals(curNailColor) && !targetScript.curColor.Equals(curNailColor)) {
                Debug.Log("颜色不一样, 发生碰撞");
                //Player.transform.position = StartPoint.transform.position;
                Debug.Log("death from Nails");
                Destroy(other.gameObject);
                Destroy(Ghost);
                //Time.timeScale = 0f; // freeze time
                GameOver();
            }
        }
    }

    // 游戏结束逻辑
    private void GameOver()
    {
        // 加载一个游戏结束场景
        SceneManager.LoadScene("NailGameOverScene");
    }
}
