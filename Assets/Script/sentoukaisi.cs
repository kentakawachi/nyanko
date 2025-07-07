using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sentoukaisi : MonoBehaviour
{
    public Button startButton;      // いざ出陣ボタン
    public GameObject startImage;   // 戦闘開始画像（UI）
    public AudioSource audioSource;    // 音楽を再生するAudioSource
    public string nextSceneName;     // 移動先のシーン名（例："BattleScene"）
    public AudioSource BGM;   // 再生中の音（BGMなど）

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 最初は画像を非表示にしておく
        startImage.SetActive(false);


        // ボタンにクリックイベントを追加
        startButton.onClick.AddListener(OnStartButtonClicked);
        audioSource = startButton.GetComponent<AudioSource>();

    }

    void OnStartButtonClicked()
    {
        startImage.SetActive(true);
        BGM.Stop(); 
        audioSource.Play();             
        Invoke("HideStartImage", 3f);
        Invoke("GoToNextScene", 3f); 
    }

    void HideStartImage()
    {
        startImage.SetActive(false);
    }
     void GoToNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

}
