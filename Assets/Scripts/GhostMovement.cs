using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Proyecto26; // 引用Proyecto26 REST库
using System;

[System.Serializable]
public class ChasingData
{
    public string levelName;
    public string ChaseDateTime;
    public int NumberOfChange;
    public string Stopped;
}

public class GhostMovement : MonoBehaviour
{
    private string firebaseUrl = "https://csci526-catandghost-default-rtdb.firebaseio.com/"; // 你的Firebase URL
    public float speed = 2.0f; // 移动速度
    private Vector2 targetPosition;

    public Vector2 minPosition = new Vector2(-5, -5); // 移动范围的最小坐标
    public Vector2 maxPosition = new Vector2(5, 5); // 移动范围的最大坐标

    public Transform target; // 目标对象的Transform组件
    public float chaseDistance = 2.5f; // 追踪的距离阈值
    private bool isChasing = false; // 是否正在追踪

    /////////////////////
    private int spaceKeyPressCount = 0;


    // 引用目标对象的脚本以访问canMove属性
    private NewBehaviourScript targetScript;

    private void Start()
    {
        // 初始化随机目标位置
        targetPosition = GetRandomPosition();
        // 获取目标对象的NewBehaviourScript组件
        targetScript = target.GetComponent<NewBehaviourScript>();

        if (SceneManager.GetActiveScene().name == "Level1")
        {
            // 当 Level 1 加载时，重置 GameData
            GameData.currentLevelIndex = 1;
        }

    }

    private void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, target.position);

        /////////////////////
        // 追逐状态下统计count
        if (isChasing && Input.GetKeyDown(KeyCode.Space))
        {
            spaceKeyPressCount++;
            Debug.Log("++");
        }
        /////////////////////

        Color32 playerColor = targetScript.curColor;
        Color32 backgroundColor = targetScript.bgColor;
        if (playerColor.Equals(backgroundColor))
        {
            /////////////////////
            if (isChasing)
            {
                isChasing = false;
                Debug.Log("Count =" + spaceKeyPressCount); // 相同颜色停止追逐输出count
                StopChasingAndUploadData("same color");
            }
            MoveToTarget();
            ///////////////////////
        }
        else
        {
            if (isChasing && distanceToTarget < chaseDistance)
            {
                ChaseTarget();
            }
            else
            {
                if (!isChasing || distanceToTarget >= chaseDistance)
                {
                    MoveToTarget();
                    if ((Vector2)transform.position == targetPosition)
                    {
                        targetPosition = GetRandomPosition();
                    }
                }
            }

            if (!isChasing && distanceToTarget < chaseDistance)
            {
                isChasing = true;
                Debug.Log("Chasing");
            }
            else if (isChasing && distanceToTarget >= chaseDistance)
            {
                /////////////////////
                Debug.Log("Count =" + spaceKeyPressCount); // 拉开距离停止追逐输出count
                StopChasingAndUploadData("longer distance");
                /////////////////////
                isChasing = false;
                targetPosition = GetRandomPosition();
            }
        }
    }

    // Analytics 调用这个方法来结束追捕并上传数据
    private void StopChasingAndUploadData(string reason)
    {
        if (!targetScript.isBeingChased)
        {
            // 记录追捕停止的数据
            ChasingData stopChasingData = new ChasingData
            {
                levelName = SceneManager.GetActiveScene().name,
                //ChaseDateTime = targetScript.startChaseTime.ToString("yyyy-MM-dd HH:mm:ss"),
                ChaseDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                //NumberOfChange = targetScript.colorChangeCount,
                NumberOfChange = spaceKeyPressCount,
                Stopped = reason
            };
            string jsonData = JsonUtility.ToJson(stopChasingData);
            RestClient.Post($"{firebaseUrl}ChaseData.json", jsonData).Then(response =>
            {
                Debug.Log("Chasing stopped data uploaded successfully!");
            }).Catch(error =>
            {
                Debug.LogError($"Failed to upload chasing stopped data: {error}");
            });

            targetScript.SetChaseStatus(false); // 设置追捕状态为 false
        }
    }

    private void ChaseTarget()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    private void MoveToTarget()
    {
        /////////////////////
        spaceKeyPressCount = 0; // 停止追逐重置count
        /////////////////////
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if ((Vector2)transform.position == targetPosition)
        {
            targetPosition = GetRandomPosition();
        }
    }

    private Vector2 GetRandomPosition()
    {
        /////////////////////
        spaceKeyPressCount = 0; // 开始追逐时重置空格键点击计数
        /////////////////////
        float randomX = UnityEngine.Random.Range(minPosition.x, maxPosition.x);
        float randomY = UnityEngine.Random.Range(minPosition.y, maxPosition.y);
        return new Vector2(randomX, randomY);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查触发器碰撞的对象是否为玩家
        if (other.gameObject == target.gameObject)
        {
            // 获取玩家的当前颜色和背景颜色
            Color32 playerColor = targetScript.curColor; // 假设NewBehaviourScript有一个公共属性或方法curColor
            Color32 backgroundColor = targetScript.bgColor; // 同样假设有公共访问方式

            Debug.Log("playerColor = " + playerColor);
            Debug.Log("backgroundColor = " + backgroundColor);

            // 对比玩家颜色和背景颜色
            if (playerColor.Equals(backgroundColor))
            {
                Debug.Log("Player's color matches the background color. Ghost disappear.");
                // 如果颜色相同，执行相应的逻辑
                //Destroy(gameObject);
            }
            else
            {
                // 如果颜色不同，执行原有逻辑
                Debug.Log("Ghost caught the player.");

                /////////////////////
                Debug.Log("Count =" + spaceKeyPressCount); // 被杀停止追逐输出count
                StopChasingAndUploadData("ghost death");
                /////////////////////


                // 生成基于当前时间的ID
                string timestampId = System.DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
                // 创建DeathData对象并填充数据
                DeathData deathData = new DeathData
                {
                    id = timestampId, // 使用时间戳作为ID
                    level = GameData.scnenName,
                    positionX = target.position.x,
                    positionY = target.position.y,
                    killedBy = "Ghost",
                    endTime = Time.timeSinceLevelLoad,
                    DeathdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") // 填充当前日期和时间
                };
                // 转换数据为JSON
                string json = JsonUtility.ToJson(deathData);

                // 发送数据到Firebase
                PostDeathDataToFirebase(json);

                Destroy(other.gameObject);
                //Time.timeScale = 0f; // freeze time
                GameOver();
            }
        }
    }

    private void PostDeathDataToFirebase(string json)
    {

        // 使用 POST 请求发送数据到 deaths 节点
        RestClient.Post($"https://csci526-catandghost-default-rtdb.firebaseio.com/deaths.json", json)
            .Then(response => {
                // Firebase的响应包含了生成的唯一键
                var id = response.Text;
                Debug.Log($"Death data uploaded successfully! ID: {id}");
            })
            .Catch(error => Debug.LogError("Error uploading death data: " + error));
    }


    // 游戏结束逻辑
    private void GameOver()
    {
        // 加载一个游戏结束场景
        SceneManager.LoadScene("GameOverScene");
    }
}
