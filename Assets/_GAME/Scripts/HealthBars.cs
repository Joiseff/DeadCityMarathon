using UnityEngine;
using UnityEngine.UI;

public class HealthBars : MonoBehaviour
{
    private PlayerHealths playerHealth; // PlayerHealth sýnýfýna eriþim saðlamak için referans
    [SerializeField] private Image healthBarFill; // Saðlýk çubuðunu dolduracak olan Image referansý
    [SerializeField] private Gradient healthGradient; // Saðlýk çubuðunun rengini belirlemek için gradient referansý

    void Start()
    {
        // Eðer playerHealth referansý atanmamýþsa, sahnedeki Player objesinden PlayerHealth bileþenini bul
        if (playerHealth == null)
        {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealths>();
        }

        // Health bar'ýn doldurma kýsmýnýn referansý atanmamýþsa, bu obje altýndaki Image bileþenini bul
        if (healthBarFill == null)
        {
            healthBarFill = GetComponentInChildren<Image>();
        }

        // Saðlýk çubuðunun baþlangýç rengini ayarla
        UpdateHealthBar();
    }

    void Update()
    {
        // Her güncellemede saðlýk çubuðunu güncelle
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        // Oyuncunun maksimum ve mevcut saðlýk deðerlerine göre saðlýk çubuðunun doluluk oranýný hesapla
        float fillAmount = (float)playerHealth.currentHealth / playerHealth.maxHealth;
        // Saðlýk çubuðunun doluluk oranýný güncelle
        healthBarFill.fillAmount = fillAmount;

        // Doluluk oranýna göre renk gradyanýndan uygun rengi seç
        healthBarFill.color = healthGradient.Evaluate(fillAmount);
    }
}
