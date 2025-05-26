using UnityEngine;
using TMPro;

public class MikataHP : MonoBehaviour
{
    public int maxHP = 1000;
    public int currentHP;
    public TextMeshProUGUI hpText;
    public GameObject victoryImage;
    public AudioClip attackSE;
    private AudioSource audioSource;
    private bool loseFlag = false;
    public BGMPlayer bgmPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHP = maxHP;
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
        }
    }
}
