using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Sonraki seviyeye ge�.
            SceneController.instance.NextLevel();
        }
    }
}
