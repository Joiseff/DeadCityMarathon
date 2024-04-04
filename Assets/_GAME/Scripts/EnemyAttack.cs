using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damageAmount = 10; // Sald�r� hasar�
    public float attackRange = 1.0f; // Sald�r� menzili
    public float attackCooldown = 1.0f; // Sald�r� aral���

    private Animator animator;
    private Transform player; // Oyuncunun pozisyonunu tutmak i�in
    private PlayerHealth playerHealth; // Oyuncunun sa�l�k bile�eni
    Rigidbody2D rb;


    private bool canAttack = true; // Sald�r�y� yapma izni

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform; // Oyuncuyu bul
        playerHealth = player.GetComponent<PlayerHealth>(); // Oyuncunun sa�l�k bile�enini al
        
    }

    void Update()
    {
        // Karakter �l� de�ilse
        if (!playerHealth.IsDead())
        {
            // Oyuncu d��man�n sald�r� menzili i�erisinde mi kontrol et
            if (Vector2.Distance(transform.position, player.position) <= attackRange && canAttack)
            {
                // Sald�r� animasyonunu oynat
                animator.SetTrigger("attack");
                // Oyuncuya hasar ver
                playerHealth.TakeDamage(damageAmount);
                // Sald�r� aral���na g�re sald�r�y� tekrar etme s�resini belirle
                canAttack = false;
                Invoke("ResetAttack", attackCooldown);
            }
        }
        else
        {
            // Karakter �ld���nde, sald�r� animasyonunu durdur
            animator.ResetTrigger("attack");
        }

        if (playerHealth.IsDead())
        {

            animator.SetTrigger("Idle");

            


        }
    }

    // Sald�r� aral���ndaki s�renin sonunda sald�r�y� tekrar etmek i�in kullan�lan fonksiyon
    void ResetAttack()
    {
        canAttack = true;
    }
}