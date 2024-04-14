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
            currentHealth -= damage; // Hasar� mevcut sa�l�ktan ��kar

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

    // Karakterin �l�p �lmedi�ini kontrol eden metod
    public bool IsDead()
    {
        return isDead;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // E�er temas edilen obje bir e�ya ise ve etiketi "HealthItem" ise
        if (other.CompareTag("HealthItem"))
        {
            AudioManager.Instance.PlaySFX("Pickup");
            // E�yay� yok et (bu objenin sahne d���na ��kmas�n� sa�lar)
            Destroy(other.gameObject);


            // Karakterin can�n� artt�r
            currentHealth += healthIncreaseAmount;

            // E�er can maksimuma ula�t�ysa, maksimum can miktar�na s�n�rla
            if (currentHealth > 200)
            {
                currentHealth = 200;
            }
        }

        
    }

    


}
