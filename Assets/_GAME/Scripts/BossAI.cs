using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target; // Karakterin transform bilgisi
    public float attackRange = 1f; // Saldırı mesafesi
    public int damageAmount = 10;
    public float attackCooldown = 1.0f;
    private bool canAttack = true;
    private PlayerHealths _playerHealth;
    private Animator animator;

    private void Start()
    {
        _playerHealth = target.GetComponent<PlayerHealths>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {

        if (!_playerHealth.IsDead())
        {

            if (target == null) // Eğer hedef belirlenmemişse (karakter belirlenmemişse)
                return;

            // Düşman ve karakter arasındaki mesafeyi hesapla
            float distanceToTarget = Vector2.Distance(transform.position, target.position);

            // Eğer karakter saldırı mesafesindeyse
            if (distanceToTarget <= attackRange)
            {
                animator.SetTrigger("attack");
                // Oyuncuya hasar ver
                _playerHealth.TakeDamage(damageAmount);

                AudioManager.Instance.PlaySFX("ZombieAttack");

                canAttack = false;
                Invoke("ResetAttack", attackCooldown);
            }

            else
            {
                // Karakter �ld���nde, sald�r� animasyonunu durdur
                animator.ResetTrigger("attack");
            }

            if (_playerHealth.currentHealth <= 0)
            {
                GetComponent<FollowPlayers>().enabled = false;

                animator.SetTrigger("Idle");
            }
        }

    }
           
    void ResetAttack()
    {
        canAttack = true;
    }


}