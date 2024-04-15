using UnityEngine;

public class FloorColorChangeScript : MonoBehaviour {

    public Color32 myR = Colors.myR;
    public Color32 myY = Colors.myY;
    public Color32 myB = Colors.myB;
    public Color[] colors; // 用于存储可能颜色的数组
    private SpriteRenderer spriteRenderer; // SpriteRenderer组件的引用

    public float minTime = 2.0f; // 更换颜色的最小时间间隔
    public float maxTime = 3.0f; // 更换颜色的最大时间间隔

    private float timer; // 计时器
    private float timeToChange; // 下一次更换颜色的时间点

    // 创建一个公共静态事件
    public static event System.Action<Color> OnColorChange;

    public Color32 curColor;

    public static bool crossingWall; //判断物体是否正在穿墙

    // 一段距离内不变颜色
    public Transform player; // player对象的Transform组件
    public Transform ghost; // ghost对象的Transform组件


    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>(); // 获取SpriteRenderer组件
        SetRandomTime(); // 初始化随机时间
        colors = new Color[] { myR, myY, myB }; // 初始化颜色数组
        curColor = myR; // 将当前颜色初始化为红色
        spriteRenderer.color = myY; // 将SpriteRenderer的颜色设置为红色
        ChangeColor();
    }

    void Update() {

        float distanceToTarget = Vector2.Distance(ghost.position, player.position);
        bool canChange = distanceToTarget > 4f;
        Debug.Log("是否距离满足变色" + canChange);

        timer += Time.deltaTime; // 更新计时器
        // 检查是否达到了更换颜色的时间
        if (timer >= timeToChange && canChange) {
            Debug.Log("是否正在穿墙" + crossingWall);
            if (!crossingWall) {
                ChangeColor(); // 更换颜色
            }
            SetRandomTime(); // 重置随机时间
        }
    }

    void ChangeColor() {
        // 从colors数组中随机选择一个颜色并应用
        curColor = colors[Random.Range(0, colors.Length)];
        spriteRenderer.color = curColor;
        // 触发事件
        OnColorChange?.Invoke(curColor);
        // 重置计时器
        timer = 0f;
    }

    void SetRandomTime() {
        // 设置下一次更换颜色的时间点
        timeToChange = Random.Range(minTime, maxTime);
    }
}