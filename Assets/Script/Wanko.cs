using UnityEngine;

public class Wanko : MonoBehaviour
{
    private Animator animator;
    private int catTouchCount = 0;
    private int siroTouch = 0;
    public int maxHP = 90;
    public int currentHP;
    public int attackPower = 8;
    public bool isMove = true;
    public float speed = 2f;
    public GameObject targetCat;  // 攻撃対象。OnTriggerEnterなどでセットする感じ
    public AudioClip attackSE;
    private AudioSource audioSource;
    private MikataHP mikatasiro;


    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsWalking", true);
        currentHP = maxHP;
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        if (isMove == true)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cat")
        {
            targetCat = collision.gameObject;
            catTouchCount++;
        }


        if (collision.gameObject.tag == "mikatasiro")
        {
            siroTouch++;
            mikatasiro = collision.GetComponent<MikataHP>();
            

        }
        if (catTouchCount == 1 || siroTouch > 0)
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsAttacking", true);
            isMove = false;
        }
    }
 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cat")

        {
            catTouchCount--;

            if (catTouchCount <= 0)
            {
                animator.SetBool("IsAttacking", false);
                animator.SetBool("IsWalking", true);
                isMove = true;

            }
        }
        if (collision.gameObject.tag == "mikatasiro")
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
    public void GetDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log($"{gameObject.name} は {damage} ダメージを受けた！ HP: {currentHP}");

        if (currentHP <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log($"{gameObject.name} は倒れた！");
        // 吹っ飛び処理をここで呼ぶとかもOK
        Destroy(gameObject);
    }
    public void GiveDamage()
    {
        if (targetCat != null)
        {
            Cat cat = targetCat.GetComponent<Cat>();
            if (cat != null)
            {
                cat.GetDamage(attackPower);
                audioSource.PlayOneShot(attackSE);
            }
        }
         if (mikatasiro != null)
        {
            mikatasiro.MikataSiroDamage(attackPower);
            Debug.Log("城にダメージを与えた！");
        }
    }
}