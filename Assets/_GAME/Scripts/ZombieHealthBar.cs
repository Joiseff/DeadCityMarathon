using UnityEngine;
using UnityEngine.UI;

public class ZombieHealthBar : MonoBehaviour
{
    private EnemyHealth _enemyHealth; // EnemyHealth sýnýfýna eriþim saðlamak için referans
    [SerializeField] private Image healthBarFill; // Saðlýk çubuðunu dolduracak olan Image referansý
    [SerializeField] private Gradient healthGradient; // Saðlýk çubuðunun rengini belirlemek için gradient referansý
    
    


   
    void Start()
    {
        // Eðer enemyHealth referansý atanmamýþsa, sahnedeki Player objesinden PlayerHealth bileþenini bul
        if (_enemyHealth == null)
        {
            _enemyHealth = GameObject.FindGameObjectWithTag("Zombie").GetComponent<EnemyHealth>();
        }

        // Health bar'ýn doldurma kýsmýnýn referansý atanmamýþsa, bu obje altýndaki Image bileþenini bul
        if (healthBarFill == null)
        {
            healthBarFill = GetComponentInChildren<Image>();
        }

        // Saðlýk çubuðunun baþlangýç rengini ayarla
        UpdateStaminaBar();
    }

    void Update()
    {
        // Her güncellemede saðlýk çubuðunu güncelle
        UpdateStaminaBar();

        



    }

    void UpdateStaminaBar()
    {
        // Oyuncunun maksimum ve mevcut saðlýk deðerlerine göre saðlýk çubuðunun doluluk oranýný hesapla
        float fillAmount = (float)_enemyHealth.currentHealth / _enemyHealth.maxHealth;
        // Saðlýk çubuðunun doluluk oranýný güncelle
        healthBarFill.fillAmount = fillAmount;

        // Doluluk oranýna göre renk gradyanýndan uygun rengi seç
        healthBarFill.color = healthGradient.Evaluate(fillAmount);
    }
}