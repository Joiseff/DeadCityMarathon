using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealths : MonoBehaviour
{
    private PlayerControllers _playerController;
    private PlayerAttacks _playerAttack;
    private DieMenu _dieMenu;
    
    

    public int maxHealth = 200;
    public int currentHealth;
    private Animator animator;
    private bool isDead = false;
    public int healthIncreaseAmount = 50;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        _playerAttack = GetComponent<PlayerAttacks>();
        _playerController = GetComponent<PlayerControllers>();
        _dieMenu = GetComponent<DieMenu>();
        
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (!isDead)
        {
            currentHealth -= damage; // Hasarý mevcut saðlýktan çýkar

            if (currentHealth <= 0)
            {
                currentHealth = 0;

                Die();

               
                

            }
        }
    }


    void Die()
    {
        isDead = true;

        animator.SetTrigger("die");
        AudioManager.Instance.PlaySFX("Male_Death");

        GetComponent<PlayerAttacks>().enabled = false;
        GetComponent<PlayerControllers>().enabled = false;
        GetComponent<PlayerHealths>().enabled = false;

        _dieMenu.DMenu();

    }

    // Karakterin ölüp ölmediðini kontrol eden metod
    public bool IsDead()
    {
        return isDead;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Eðer temas edilen obje bir eþya ise ve etiketi "HealthItem" ise
        if (other.CompareTag("HealthItem"))
        {
            AudioManager.Instance.PlaySFX("Pickup");
            // Eþyayý yok et (bu objenin sahne dýþýna çýkmasýný saðlar)
            Destroy(other.gameObject);


            // Karakterin canýný arttýr
            currentHealth += healthIncreaseAmount;

            // Eðer can maksimuma ulaþtýysa, maksimum can miktarýna sýnýrla
            if (currentHealth > 200)
            {
                currentHealth = 200;
            }
        }

        
    }

    


}
