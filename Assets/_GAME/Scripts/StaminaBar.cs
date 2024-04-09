using UnityEngine;
using UnityEngine.UI;

public class StaminaBars : MonoBehaviour
{
    private PlayerControllers playerController; // PlayerHealth sýnýfýna eriþim saðlamak için referans
    [SerializeField] private Image staminaBarFill; // Saðlýk çubuðunu dolduracak olan Image referansý
    [SerializeField] private Gradient staminaGradient; // Saðlýk çubuðunun rengini belirlemek için gradient referansý

    void Start()
    {
        // Eðer playerHealth referansý atanmamýþsa, sahnedeki Player objesinden PlayerHealth bileþenini bul
        if (playerController == null)
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllers>();
        }

        // Health bar'ýn doldurma kýsmýnýn referansý atanmamýþsa, bu obje altýndaki Image bileþenini bul
        if (staminaBarFill == null)
        {
            staminaBarFill = GetComponentInChildren<Image>();
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
        float fillAmount = (float)playerController.energy / playerController.maxEnergy;
        // Saðlýk çubuðunun doluluk oranýný güncelle
        staminaBarFill.fillAmount = fillAmount;

        // Doluluk oranýna göre renk gradyanýndan uygun rengi seç
        staminaBarFill.color = staminaGradient.Evaluate(fillAmount);
    }
}
