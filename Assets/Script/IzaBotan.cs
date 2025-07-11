using UnityEngine;
using UnityEngine.UI;

public class IzaBotan : MonoBehaviour
{
    public GameObject bigCatImage;  // 猫画像（Imageの親オブジェクト）
    void Start()
    {
        bigCatImage.SetActive(false);
    }

    public void OnDeployButtonPressed()
    {
        StartCoroutine(ShowBigCat());
    }
    private System.Collections.IEnumerator ShowBigCat()
    {
        bigCatImage.SetActive(true);

        // 表示時間
        yield return new WaitForSeconds(3f);

        bigCatImage.SetActive(false);
    }
}
