using UnityEngine;
using UnityEngine.UI;

public class StaminaBars : MonoBehaviour
{
    private PlayerControllers playerController; // PlayerHealth sýnýfýna eriþim saðlamak için referans
    [SerializeField] private Image staminaBarFill; // Saðlýk çubuðunu dolduracak olan Image referansý
    [SerializeField] private Gradient staminaGradient; // Saðlýk çubuðunun rengini belirlemek için gradient referansý

    public int StaminaIncreaseAmount = 50;



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

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Eðer temas edilen obje bir eþya ise ve etiketi "HealthItem" ise
        if (other.CompareTag("StaminaItem"))
        {
            AudioManager.Instance.PlaySFX("Pickup");
            // Eþyayý yok et (bu objenin sahne dýþýna çýkmasýný saðlar)
            Destroy(other.gameObject);

            // Karakterin canýný arttýr
            playerController.energy += StaminaIncreaseAmount;

            // Eðer can maksimuma ulaþtýysa, maksimum can miktarýna sýnýrla
            if (playerController.energy > 200)
            {
                playerController.energy = 200;
            }
        }


    }


}
