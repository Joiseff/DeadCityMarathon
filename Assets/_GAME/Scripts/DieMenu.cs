using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieMenu : MonoBehaviour
{
    [SerializeField] GameObject dieMenu;
    [SerializeField] GameObject pauseButton;

    

    private void Start()
    {
        
    }
    public void DMenu()
    {
        dieMenu.SetActive(true);
        Time.timeScale = 0;
        pauseButton.SetActive(false);
 

    }


    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;



    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;

    }
}