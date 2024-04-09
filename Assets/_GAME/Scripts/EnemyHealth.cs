using UnityEngine;

public class EnemyHealths : MonoBehaviour
{
    public int maxHealth = 100; // D��man�n maksimum sa�l�k de�eri
    public int currentHealth; // D��man�n mevcut sa�l�k de�eri
    private Animator animator;
    private FollowPlayers _followPlayer;
       

    void Start()
    {
        currentHealth = maxHealth; // Ba�lang��ta d��man�n sa�l�k de�eri maksimum sa�l�k de�erine e�it olacak
        animator = GetComponent<Animator>();
        _followPlayer = GetComponent<FollowPlayers>();
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Gelen hasar kadar d��man�n sa�l�k de�erini azalt

        if (currentHealth <= 0)
        {
            Enemydie(); // E�er d��man�n sa�l�k de�eri 0 veya daha az ise, d��man� �ld�r
        }
    }

    void Enemydie()
    {
        
        animator.SetTrigger("Die");
        GetComponent<FollowPlayers>().enabled = false;
        
        
    }

    void CleanEnemy()
    {

        Destroy(gameObject);
    }
}
