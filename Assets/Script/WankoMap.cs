using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WankoMap : MonoBehaviour
{
    public Transform character;
    public float moveSpeed = 5f;
    public TextMeshProUGUI stageNameText;

    private Vector2 targetPos;
    private string currentStageName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPos = character.position;
        stageNameText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector2)character.position != targetPos)
        {
            character.position = Vector2.MoveTowards(character.position, targetPos, moveSpeed * Time.deltaTime);
        }
        else
        {
            stageNameText.text = currentStageName;
        }
    }
    public void MoveToStage(Vector2 pos, string stageName)
    {
        targetPos = pos;
        Debug.Log(targetPos);
        currentStageName = stageName;
        stageNameText.text = ""; // 移動中は非表示
    }
}
