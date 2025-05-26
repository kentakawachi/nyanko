using UnityEngine;

public class KnockbackEffect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public float knockbackPower = 5f;         // ノックバック力
    public float bounceHeight = 2f;           // バウンドの高さ
    public float bounceDuration = 0.3f;       // 1回のバウンド時間
    public int bounceCount = 2;               // バウンド回数

    private bool isKnockingBack = false;
    private Vector3 originalRotation;
    public Collider2D myCollider;

    public void StartKnockback(bool goLeft)
    {
        if (isKnockingBack) return;

        isKnockingBack = true;
        originalRotation = transform.eulerAngles;

        // 向きで方向を変える
        float direction = goLeft ? 1f : -1f;

        // アニメーション開始
        StartCoroutine(KnockbackRoutine(direction));
    }

    private System.Collections.IEnumerator KnockbackRoutine(float direction)
    {
        myCollider.enabled = false; // 衝突判定OFF

        // 倒れる（傾ける）
        transform.rotation = Quaternion.Euler(0f, 0f, 30f * -direction);

        Vector3 startPos = transform.position;

        for (int i = 0; i < bounceCount; i++)
        {
            float timer = 0f;
            Vector3 peak = startPos + new Vector3(direction * knockbackPower / bounceCount, bounceHeight, 0f);
            Vector3 end = startPos + new Vector3(direction * knockbackPower * (i + 1) / bounceCount, 0f, 0f);

            while (timer < bounceDuration)
            {
                float t = timer / bounceDuration;
                Vector3 jumpPos = Vector3.Lerp(Vector3.Lerp(startPos, peak, t), Vector3.Lerp(peak, end, t), t);
                transform.position = jumpPos;
                timer += Time.deltaTime;
                yield return null;
            }

            startPos = end;
        }

        // 元の角度に戻す
        transform.rotation = Quaternion.Euler(originalRotation);
        myCollider.enabled = true; // 衝突判定ON
        
        isKnockingBack = false;
    }  
}