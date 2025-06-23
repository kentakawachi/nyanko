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
        // 戦闘開始画像を表示
        startImage.SetActive(true);
        BGM.Stop(); // 音を止める
        audioSource.Play();             // 音楽を再生
        // 必要なら、一定時間後に非表示にしたり、次のシーンに進んだりも可能
        // 例：3秒後に非表示にする場合
        Invoke("HideStartImage", 3f);
        Invoke("GoToNextScene", 3f); // 3秒後にシーン移動
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
