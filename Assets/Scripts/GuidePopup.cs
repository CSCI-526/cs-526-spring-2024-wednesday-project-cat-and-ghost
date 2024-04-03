using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidePopup : MonoBehaviour {
    public GameObject currentObject; // 当前要关闭的GameObject
    public GameObject nextObject;    // 要显示的下一个GameObject

    public int currentScene;

    // 记录距离
    public Transform objectToTrack; // 在Inspector中指定要跟踪的对象
    private Vector3 startPosition;
    private float totalDistanceMoved = 0f;
    private float xPosition = -5f;

    // Start is called before the first frame update
    void Start() {
        // 记录玩家的初始位置
        if (objectToTrack != null) {
            startPosition = objectToTrack.position;
        }
    }

    // Update is called once per frame
    void Update() {
        if (objectToTrack != null) {
            // 计算并更新总移动距离
            totalDistanceMoved = Vector3.Distance(startPosition, objectToTrack.position);
            Debug.Log(objectToTrack.name + " has moved a total distance of: " + totalDistanceMoved);

            // 获取当前游戏对象的x坐标
            xPosition = objectToTrack.position.x;
            Debug.Log(gameObject.name + " X Position: " + xPosition);
        }

        // 使用Input.GetKeyDown获取键盘输入
        if (currentScene == 0 && Input.GetKeyDown(KeyCode.Space)) {
            LoadNextGuide();
        } else if (currentScene == 1 && totalDistanceMoved >= 1) {
            LoadNextGuide();
        } else if (currentScene == 2 && xPosition > -1.1) {
            LoadNextGuide();
        }

    }

    public void LoadNextGuide() {
        if (currentObject != null) {
            currentObject.SetActive(false); // 关闭当前GameObject
        }

        if (nextObject != null) {
            nextObject.SetActive(true); // 显示下一个GameObject
        }
    }
}
