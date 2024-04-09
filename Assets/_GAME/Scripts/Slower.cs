using UnityEngine;

public class Slowers : MonoBehaviour
{
    // Yavaþlatma katsayýsý
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Karakter zemine temas ettiðinde kontrol edelim
        if (collision.CompareTag("Player"))
        {
            // Karakterin hýzýný yavaþlat
            PlayerControllers player = collision.GetComponent<PlayerControllers>();
            player.moveSpeed = 0.5f;
        }
        

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Karakterin hýzýný yavaþlat
            PlayerControllers player = collision.GetComponent<PlayerControllers>();
            player.moveSpeed = 2.0f;
        }
    }


}