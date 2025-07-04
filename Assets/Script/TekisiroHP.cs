using UnityEngine;
using TMPro;

public class TekisiroHP : MonoBehaviour
{
    public int maxHP = 1000;
    public GameObject[] enemyPrefabs; // 複数の敵プレハブを登録
    public Transform spawnPoint;      // 敵の城の位置
    public float spawnInterval = 5f;  // 出現間隔（秒）
    public int currentHP;
    private float timer = 0f;
    public TextMeshProUGUI hpText;
    public GameObject victoryImage;
    public AudioClip attackSE;
    private AudioSource audioSource;
    private bool winFlag = false;
    public BGMPlayer bgmPlayer;
    // ← 画像を扱う用
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHP = maxHP;
        UpdateHPText();
        audioSource = GetComponent<AudioSource>();

        if (victoryImage != null)
            victoryImage.SetActive(false); // 最初は非表示
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnRandomEnemy();
            timer = 0f;
        }
    }

    public void TakeSiroDamage(int damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Max(currentHP, 0); // マイナスにならないように
        UpdateHPText();

        if (currentHP <= 0)
        {
            OnCastleDestroyed();
            winFlag = true;

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
        if (winFlag) return;
        if (victoryImage != null)
        {
            Debug.Log("敵の体力0");
            audioSource.PlayOneShot(attackSE);

            victoryImage.SetActive(true);
        }

        // 他の演出（音やアニメなど）もここで追加可能
    }
    void SpawnRandomEnemy()
    {
        if (enemyPrefabs.Length == 0) return;

        int index = Random.Range(0, enemyPrefabs.Length);
        GameObject enemy = Instantiate(enemyPrefabs[index], spawnPoint.position, Quaternion.identity);
            Debug.Log($"出現: {enemy.name}");

    }
}
