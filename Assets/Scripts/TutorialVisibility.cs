using UnityEngine;

public class TutorialVisibility : MonoBehaviour {
    public GameObject targetObject;
    void Update() {
        if (Input.GetKeyDown(KeyCode.T)) // 假设使用T键作为切换键
        {
            if (targetObject != null) {
                bool isActive = targetObject.activeSelf;
                targetObject.SetActive(!isActive);
                Debug.Log($"Set {targetObject.name} active state to {!isActive}");
            }
        }
    }
}
