using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int maxLevel = 10; // 最大关卡数
    string CurrentsceneName = GameData.scnenName; //最新Scene名

    // 从场景名提取关卡索引
    private void Start()
    {
        if (CurrentsceneName.StartsWith("Level"))
        {
            string indexStr = CurrentsceneName.Substring(CurrentsceneName.Length - 1);
            int levelIndex;

            // 尝试将索引字符串转换为数字
            if (int.TryParse(indexStr, out levelIndex))
            {
                // 更新当前关卡索引
                GameData.currentLevelIndex = levelIndex;
                Debug.LogError("Debug Index:"+ levelIndex);
            }
            else
            {
                Debug.LogError("Unable to parse level index from scene name.");
            }
        }
    }


    // 调用这个方法以加载下一个关卡
    public void LoadNextLevel()
    {
        // 计算下一个关卡索引
        int nextLevelIndex = GameData.currentLevelIndex + 1;


        // 检查是否达到最大关卡数
        if (nextLevelIndex <= maxLevel)
        {
            // 更新 GameData 中的当前关卡索引
            GameData.currentLevelIndex = nextLevelIndex;
            // 构建新关卡的场景名
            string levelSceneName = "Level" + nextLevelIndex.ToString();
            Debug.Log("loadScene:"+levelSceneName);

            // 加载下一个关卡
            SceneManager.LoadScene(levelSceneName);
        }
        else
        {
            // 如果已是最后一个关卡，可以加载游戏结束或返回主菜单的场景
            Debug.Log("Congratulations! You've completed all levels.");
            // 示例：返回主菜单
            // SceneManager.LoadScene("MainMenu");
        }
    }
}
