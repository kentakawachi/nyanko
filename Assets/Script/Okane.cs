
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Okane : MonoBehaviour
{

    public int money = 0;
    public int maxMoney = 6000;
    public float baseIncomeRate = 5f;
    private float currentIncomeRate;
    public int level = 1;
    private int[] maxMoneyPerLevel = { 0, 6000, 7500, 9000, 10000 };
    public float interval = 0.1f; // 1秒ごとに増やす
    public int moneyPerInterval = 1; // 増加量

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI levelText;
    public Button levelUpButton;
    public TextMeshProUGUI updateLevelText;

    private float timer;
    private int[] levelUpCosts = { 0, 560, 1120, 1680 };

    void Start()
    {
        currentIncomeRate = baseIncomeRate;
        UpdateMoneyText();
 
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.01f)
        {
            timer = 0f;
            money += Mathf.FloorToInt(currentIncomeRate);
            money = Mathf.Min(money, maxMoney);
            UpdateMoneyText();
        }
    }
    
    public void OnLevelUpButtonPressed()
    {
        if (level >= 4)
        {
            Debug.Log("最大レベルに到達しています！");
            return;
        }

        int nextCost = levelUpCosts[level]; // 現在のレベルの次のコスト

        if (money >= nextCost)
        {
            money -= nextCost;
            level++;
            currentIncomeRate += 2f;
            maxMoney = maxMoneyPerLevel[level]; // ← ここで更新！

            UpdateMoneyText();

            if (level >= 4)
            {
                levelText.text = $"{level}";
                updateLevelText.text = "MAX";
                levelUpButton.interactable = false; // ボタンを無効化
            }
        }
        else
        {
            Debug.Log("お金が足りません！");
        }
    }
    
    public void UpdateMoneyText()
    {
        moneyText.text = $" {money} / {maxMoney}";
        if (level < 4)
        {
            levelText.text = $"{level}";
            updateLevelText.text = $"{levelUpCosts[level]}";
            
        }
    }
}
       
  