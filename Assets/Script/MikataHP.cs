using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class MikataHP : MonoBehaviour
{
    public GameObject kontenyu;  // 猫画像（Imageの親オブジェクト）
    
    public int maxHP = 1000;
    public int currentHP;
    public TextMeshProUGUI hpText;
    public GameObject victoryImage;
    public AudioClip attackSE;
    private AudioSource audioSource;
    private bool loseFlag = false;
    public BGMPlayer bgmPlayer;
    public string nextSceneName;     // 移動先のシーン名（例："BattleScene"）


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHP = maxHP;
        kontenyu.SetActive(false);
        UpdateHPText();
        audioSource = GetComponent<AudioSource>();

        if (victoryImage != null)
            victoryImage.SetActive(false); // 最初は非表示
    }

    public void MikataSiroDamage(int damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Max(currentHP, 0); // マイナスにならないように
        UpdateHPText();

        if (currentHP <= 0)
        {
            OnCastleDestroyed();
            loseFlag = true;

            if (bgmPlayer != null)
            {
                bgmPlayer.StopBGM();
            }
        }
    }
    // Update is called once per frame
    void UpdateHPText()
    {
        hpText.text = currentHP + " / " + maxHP;
    }
    void OnCastleDestroyed()

    {
        if (loseFlag) return;
        if (victoryImage != null)
        {
            Debug.Log("味方の体力0");
            audioSource.PlayOneShot(attackSE);
            victoryImage.SetActive(true);
            StartCoroutine(BackScene());
        }
    }
    private System.Collections.IEnumerator BackScene()
    {
        kontenyu.SetActive(true);
        yield return new WaitForSeconds(3f);
        kontenyu.SetActive(false);
        SceneManager.LoadScene(nextSceneName);
     
    }
}
