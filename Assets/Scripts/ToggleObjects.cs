using UnityEngine;

public class ToggleObjects : MonoBehaviour {
    public GameObject currentObject; // 当前要关闭的GameObject
    public GameObject nextObject;    // 要显示的下一个GameObject

    public GameObject showObject;    // 要显示的下一个GameObject
    public bool isFirst;
    bool isKeyPress = false;

    // 此方法应该被绑定到按钮的OnClick事件
    public void OnButtonClick() {
        if(isFirst) {
            if(isKeyPress) {
                showObject.SetActive(false);

                if (currentObject != null) {
                    currentObject.SetActive(false); // 关闭当前GameObject
                }

                if (nextObject != null) {
                    nextObject.SetActive(true); // 显示下一个GameObject
                }
            }

        } else {
            if (currentObject != null) {
                currentObject.SetActive(false); // 关闭当前GameObject
            }

            if (nextObject != null) {
                nextObject.SetActive(true); // 显示下一个GameObject
            }
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            isKeyPress = true;
        }
    }
}