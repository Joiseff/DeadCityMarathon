using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Düþmanýn maksimum saðlýk deðeri
    public int currentHealth; // Düþmanýn mevcut saðlýk deðeri
    private Animator animator;
    private FollowPlayer _followPlayer;
       

    void Start()
    {
        currentHealth = maxHealth; // Baþlangýçta düþmanýn saðlýk deðeri maksimum saðlýk deðerine eþit olacak
        animator = GetComponent<Animator>();
        _followPlayer = GetComponent<FollowPlayer>();
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Gelen hasar kadar düþmanýn saðlýk deðerini azalt

        if (currentHealth <= 0)
        {
            Enemydie(); // Eðer düþmanýn saðlýk deðeri 0 veya daha az ise, düþmaný öldür
        }
    }

    void Enemydie()
    {
        
        animator.SetTrigger("Die");
        GetComponent<FollowPlayer>().enabled = false;
        
        
    }

    void CleanEnemy()
    {

        Destroy(gameObject);
    }
}
