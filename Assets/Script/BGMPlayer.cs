using UnityEngine;

public class BGMPlayer : MonoBehaviour
{


    public AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource != null)
        {
            audioSource.Play(); // 自動再生（必要なら）
        }
    }
    public void StopBGM()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
            Debug.Log("BGM stopped");
        }

    }
}
