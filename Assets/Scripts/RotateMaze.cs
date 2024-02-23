using UnityEngine;

public class RotateMaze : MonoBehaviour
{

    public float minRotateTime = 8.0f; // 旋转迷宫最小时间间隔
    public float maxRotateTime = 9.0f; // 旋转迷宫最大时间间隔

    private float timerRotate; // 旋转计时器
    private float timeToRotate; // 下一次旋转迷宫的时间点

    void Start()
    {
        SetRandomRotateTime();
    }

    void Update()
    {
        // 更新计时器
        timerRotate += Time.deltaTime;
        // 检查是否达到了旋转迷宫的时间
        if (timerRotate >= timeToRotate)
        {
            Rotate(); // 旋转迷宫
            SetRandomRotateTime(); // 重置随机时间
        }
    }

    void Rotate()
    {
        // 旋转物体180度，以Y轴为旋转轴
        transform.Rotate(0, 0, -90);
        // 获取当前位置
        Vector3 currentPosition = transform.position;

        // 将X和Y位置坐标都乘以-1
        float tmp = currentPosition.x;
        currentPosition.x = currentPosition.y;
        currentPosition.y = tmp * -1;

        // 更新物体的位置
        transform.position = currentPosition;
        // 重置计时器
        timerRotate = 0f;

    }

    void SetRandomRotateTime()
    {
        // 设置下一次旋转迷宫的的时间点
        timeToRotate = Random.Range(minRotateTime, maxRotateTime);
    }
}