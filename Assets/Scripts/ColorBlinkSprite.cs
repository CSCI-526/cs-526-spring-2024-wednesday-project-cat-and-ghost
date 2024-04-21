using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlinkSprite : MonoBehaviour
{
    public float blinkInterval = 0.5f;  // 闪烁间隔，单位是秒
    private SpriteRenderer spriteRenderer;
    private bool isBlinking = false;  // 当前是否正在闪烁
    private Color originalColor;  // 原始颜色
    private Color blinkColor = Color.yellow;  // 闪烁颜色

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  // 获取Sprite Renderer组件
        originalColor = spriteRenderer.color;  // 保存原始颜色
        StartCoroutine(Blink());  // 开始闪烁协程
    }

    IEnumerator Blink()
    {
        while (true)
        {
            isBlinking = !isBlinking;  // 切换闪烁状态
            spriteRenderer.color = isBlinking ? blinkColor : originalColor;  // 根据闪烁状态设置颜色
            yield return new WaitForSeconds(blinkInterval);  // 等待指定的时间间隔
        }
    }
}
