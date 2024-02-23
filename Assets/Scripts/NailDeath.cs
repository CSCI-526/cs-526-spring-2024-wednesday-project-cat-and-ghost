using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NailDeath : MonoBehaviour
{
    public GameObject Player;
    public GameObject Ghost;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")|| other.gameObject == Player)
        {
            //Player.transform.position = StartPoint.transform.position;
            Debug.Log("death from Nails");
            Destroy(other.gameObject);
            Destroy(Ghost);
            Time.timeScale = 0f; // freeze time
            GameOver();
        }
    }

    // 游戏结束逻辑
    private void GameOver()
    {
        // 加载一个游戏结束场景
        SceneManager.LoadScene("NailGameOverScene");
    }
}
