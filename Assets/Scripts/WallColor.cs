using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallColor : MonoBehaviour
{
    public Color32 curWallColor; // 当前nail的颜色

    public Transform target; // 目标对象的Transform组件
    private NewBehaviourScript targetScript;
    private Renderer wallRenderer;
    private BoxCollider2D wallCollider;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        targetScript = target.GetComponent<NewBehaviourScript>();
        wallRenderer = GetComponent<Renderer>();
        wallCollider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //如果当前墙和背景颜色一样
        if (curWallColor.Equals(targetScript.bgColor))
        {
            //将墙移到最底层
            wallRenderer.sortingLayerName = "hiddenWall";
            //设置trigger
            wallCollider.isTrigger = true;
        }
        else {
            wallRenderer.sortingLayerName = "Default";
            wallCollider.isTrigger = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        FloorColorChangeScript.crossingWall = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        FloorColorChangeScript.crossingWall = false;
    }
}
