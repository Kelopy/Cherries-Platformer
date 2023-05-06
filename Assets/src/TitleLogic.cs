using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleLogic : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject statsMenu;

    public void Play()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Statistics()
    {
        mainMenu.SetActive(false);
        statsMenu.SetActive(true);
    }

    public void OptionsBack()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void StatsBack()
    {
        mainMenu.SetActive(true);
        statsMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
