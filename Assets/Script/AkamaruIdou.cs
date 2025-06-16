using UnityEngine;

public class AkamaruIdou : MonoBehaviour
{
    public WankoMap wankoMap;
    public string stageName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        Vector2 pos = transform.position;
        wankoMap.MoveToStage(pos, stageName);
        Debug.Log(stageName + "へ移動");

    }
}
