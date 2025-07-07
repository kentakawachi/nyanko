using UnityEngine;
using UnityEngine.UI;

public class gazounoneko : MonoBehaviour
{
    public GameObject bigCatImage;  // 猫画像（Imageの親オブジェクト）

    public void OnDeployButtonPressed()
    {
        StartCoroutine(ShowBigCat());
    }
   private System.Collections.IEnumerator ShowBigCat()
    {
        bigCatImage.SetActive(true);

        // 表示時間
        yield return new WaitForSeconds(2f);

        bigCatImage.SetActive(false);
    }
}
