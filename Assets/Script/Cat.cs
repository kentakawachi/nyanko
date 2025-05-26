using UnityEngine;

public class Cat : MonoBehaviour , Animal
{
	private bool hasKnockbacked = false;
    public GameObject angelPrefab; // 天使のプレハブ（別オブジェクト）
	private KnockbackEffect knockback;
    private Animator animator;
    private int enemyTouchCount = 0;
    private int siroTouch = 0;
    public int maxHP = 100;
    public int currentHP;
    public int attackPower = 20;
    public bool isMove = true;
    public float speed = 2f;
    public float knockbackTrigger = 0.5f;
    public GameObject targetAnimal;  // 攻撃対象。OnTriggerEnterなどでセットする感じ
    public AudioClip attackSE;
    private AudioSource audioSource;
    private TekisiroHP tekisiro;



    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsWalking", true);
        currentHP = maxHP;
        audioSource = GetComponent<AudioSource>();
        knockback = GetComponent<KnockbackEffect>();


    }

    // Update is called once per frame
    void Update()
    {
        if (isMove == true)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    public void GetDamage(int damage)

    {
        currentHP -= damage;
        Debug.Log($"{gameObject.name} は {damage} ダメージを受けた！ HP: {currentHP}");

         if (!hasKnockbacked && currentHP <=  maxHP * knockbackTrigger)
        {
            hasKnockbacked = true;

            bool goLeft = true;
            knockback.StartKnockback(goLeft);
        }

        if (currentHP <= 0)
        {
            Die();
            BecomeAngel();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "tekisiro")
        {
            siroTouch++;
            tekisiro = collision.GetComponent<TekisiroHP>();


        }
        if (collision.gameObject.tag == "Enemy")
        {
            targetAnimal = collision.gameObject;
            enemyTouchCount++;
        }

        if (enemyTouchCount == 1|| siroTouch > 0)
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsAttacking", true);
            isMove = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyTouchCount--;

            if (enemyTouchCount <= 0)
            {
                animator.SetBool("IsAttacking", false);
                animator.SetBool("IsWalking", true);
                isMove = true;
            }
        }
         if (collision.gameObject.tag == "tekisiro")
          {

            siroTouch--;
            if (siroTouch <= 0)
            {
                animator.SetBool("IsAttacking", false);
                animator.SetBool("IsWalking", true);
                isMove = true;

            }
        }
    }
    void Die()
    {
        Debug.Log($"{gameObject.name} は倒れた！");
        Destroy(gameObject);
    }


    public void GiveDamage()
    {
        if (targetAnimal != null)
        {
            Animal animal = targetAnimal.GetComponent<Animal>();
            if (animal != null)
            {
                animal.GetDamage(attackPower);
                audioSource.PlayOneShot(attackSE);
            }
        }

        if (tekisiro != null)
        {
            tekisiro.TakeSiroDamage(attackPower);
            Debug.Log("城にダメージを与えた！");
        }
    }
    private void BecomeAngel () {
	Vector3 spawnPos =  transform.position;
  GameObject angel = Instantiate(angelPrefab, spawnPos, Quaternion.identity);
}
}