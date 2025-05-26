
using TMPro;
using UnityEngine;

public class Okane : MonoBehaviour
{

    public int money = 0;
    public float interval = 0.1f; // 1秒ごとに増やす
    public int moneyPerInterval = 1; // 増加量

    public TextMeshProUGUI moneyText;

    void Start()
    {
        InvokeRepeating("IncreaseMoney", interval, interval);
        UpdateMoneyText();
    }

    void IncreaseMoney()
    {
        money += moneyPerInterval;
        UpdateMoneyText();
    }

    public void UpdateMoneyText()
    {
        moneyText.text =  money.ToString();
    }
}
       
  