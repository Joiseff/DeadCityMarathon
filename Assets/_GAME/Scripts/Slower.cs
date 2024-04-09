using UnityEngine;

public class Slowers : MonoBehaviour
{
    // Yava�latma katsay�s�
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Karakter zemine temas etti�inde kontrol edelim
        if (collision.CompareTag("Player"))
        {
            // Karakterin h�z�n� yava�lat
            PlayerControllers player = collision.GetComponent<PlayerControllers>();
            player.moveSpeed = 0.5f;
        }
        

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Karakterin h�z�n� yava�lat
            PlayerControllers player = collision.GetComponent<PlayerControllers>();
            player.moveSpeed = 2.0f;
        }
    }


}