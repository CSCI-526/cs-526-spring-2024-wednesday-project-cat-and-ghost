using UnityEngine;
using System.Collections;

public class AlphaBlinkSprite : MonoBehaviour
{
    public float blinkInterval = 0.8f;  // 闪烁间隔
    private SpriteRenderer spriteRenderer;
    private float minAlpha = 0.3f;  // 最小透明度
    private float maxAlpha = 1.0f;  // 最大透明度

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  // 获取Sprite Renderer组件
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, maxAlpha);  // 初始化为完全不透明
        StartCoroutine(Blink());  // 开始闪烁协程
    }

    IEnumerator Blink()
    {
        while (true)
        {
            // 将当前透明度设置为最小或最大
            float targetAlpha = spriteRenderer.color.a == maxAlpha ? minAlpha : maxAlpha;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, targetAlpha);

            yield return new WaitForSeconds(blinkInterval);  // 等待指定的时间间隔
        }
    }
}
