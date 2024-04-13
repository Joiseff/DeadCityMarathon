using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UnlockNewLevel();

            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int totalSceneCount = SceneManager.sceneCountInBuildSettings;

            if (currentSceneIndex < totalSceneCount - 1)
            {
                // Bir sonraki sahne varsa geç
                SceneController.instance.NextLevel();
            }
            //else
            //{
            //    // Sonraki sahne yoksa ana menüye dön
            //    GoToCredit();
            //}
        }
    }
    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
    //void GoToCredit()
    //{
    //    SceneManager.LoadScene("Credit"); // Credit sahnesine gider.
    //}
}
