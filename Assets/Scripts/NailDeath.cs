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

    private PolygonCollider2D nailCollider;

    // Start is called before the first frame update
    void Start()
    {
        targetScript = target.GetComponent<NewBehaviourScript>();
        nailRender = GetComponent<Renderer>();
        nailCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //如果颜色一样
        if (targetScript.bgColor.Equals(curNailColor))
        {
            nailRender.sortingLayerName = "hiddenNails";
            nailCollider.isTrigger = true;
        }
        else
        {
            nailRender.sortingLayerName = "Default";
            nailCollider.isTrigger = false;
            //如果重叠则游戏结束
            if (CheckOverlap())
            {
                Debug.Log("重叠, 当前trigger" + nailCollider.isTrigger);
                Destroy(Player);
                Destroy(Ghost);
                //Time.timeScale = 0f; // freeze time
                GameOver();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject == Player)
        {
            //判断钉子和背景颜色是否一样,如果不一样则可以碰撞
            //钉子和玩家颜色不一样可以碰撞
            if (!targetScript.bgColor.Equals(curNailColor) && !targetScript.curColor.Equals(curNailColor))
            {
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

    bool CheckOverlap()
    {
        // 获取玩家和长方形的碰撞器
        Collider2D playerCollider = Player.GetComponent<Collider2D>();
        Collider2D triangleCollider = gameObject.GetComponent<Collider2D>();

        if (playerCollider != null && triangleCollider != null)
        {
            // 获取玩家和长方形的包围盒
            Bounds playerBounds = playerCollider.bounds;
            Bounds rectangleBounds = triangleCollider.bounds;

            // 检查两个包围盒是否相交
            bool overlap = playerBounds.Intersects(rectangleBounds);

            //重合并且钉子和玩家颜色不一样
            return overlap && !targetScript.curColor.Equals(curNailColor);
        }
        return false;
    }

    // 游戏结束逻辑
    private void GameOver()
    {
        // 加载一个游戏结束场景
        SceneManager.LoadScene("NailGameOverScene");
    }
}
