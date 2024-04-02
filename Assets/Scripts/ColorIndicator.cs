using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorIndicator : MonoBehaviour
{
    // 预定义颜色
    public Color32 myR = Colors.myR;
    public Color32 myY = Colors.myY;
    public Color32 myB = Colors.myB;

    private Color[] colors; // 存储颜色的数组
    private String[] arrows;
    private NewBehaviourScript targetScript;
    public Transform target; // 目标对象的Transform组件

    private SpriteRenderer arrowRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //初始化颜色数组
        colors = new Color[] { myB, myY, myR }; // 初始化颜色数组
        arrows = new String[] { "BlueArrow", "YellowArrow", "RedArrow"};
        //获取indicator renderer
        arrowRenderer = GetComponent<SpriteRenderer>();
        targetScript = target.GetComponent<NewBehaviourScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //获取当前颜色的索引
        int curColorIndex = Array.IndexOf(colors, targetScript.curColor);
        int indicatorColorIndex = (curColorIndex + 1) % 3;
        //如果下一个颜色的tag是当前箭头则显示，否则不显示
        if (gameObject.CompareTag(arrows[indicatorColorIndex]))
        {
            Debug.Log("当前tag为" + gameObject.tag);
            arrowRenderer.enabled = true;
        }
        else {
            arrowRenderer.enabled = false;
        }
    }
}
