using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CheckPointData
{
    public string levelName;
    public string checkedDateTime;
    public string Checkpoint;
    public string gameStatus;
}

public class GameData : MonoBehaviour
{
    //保存latest 游戏level，用于重新开始
    public static int currentLevelIndex = 1;
    public static string scnenName;
    public static CheckPointData checkPointdata;
}
