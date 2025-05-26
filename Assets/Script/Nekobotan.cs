using UnityEngine;
using UnityEngine.UI;

public class CatSpawner : MonoBehaviour
{
    public float cooldownTime = 3f;
	public Color activeColor = Color.white;
    public Color cooldownColor = new Color(0f, 0f, 0f, 0.5f);
    private bool isCooldown = false;
    private float cooldownTimer = 0f;
    public Image buttonImage;

    public GameObject catPrefab;      
    public Transform spawnPoint;        
    public int catCost = 50; 

    public Okane moneyManager; 

     void Update()
    {
        // クールダウン処理
        if (isCooldown)
        {
            cooldownTimer -= Time.deltaTime;
		
            if (cooldownTimer <= 0f)
            {
                isCooldown = false;
            }
        }
    }


    // Update is called once per frame
    public void SpawnCat()
    {
        Debug.Log("SpawnCat");
       if (isCooldown)
        {
            Debug.Log("クールダウン中！");
            return;
        }

        if (moneyManager.money >= catCost)
        {
            moneyManager.money -= catCost;
            moneyManager.UpdateMoneyText(); 
        Instantiate(catPrefab, spawnPoint.position, Quaternion.identity);   

         // クールダウン開始
            isCooldown = true;
            cooldownTimer = cooldownTime;
        }
        else
        {
            Debug.Log("お金が足りません！");
        }
    }
    
}
