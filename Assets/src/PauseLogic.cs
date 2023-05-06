using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseLogic : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private AudioMixer masterMixer;
    private float musicVolPref;
    private float SFXVolPref;
    public bool isPaused;

    public void SetSound(string sound, float soundLevel)
    {
        masterMixer.SetFloat(sound, soundLevel);
    }

    private void Start()
    {
        masterMixer.GetFloat("musicVol", out musicVolPref);
        masterMixer.GetFloat("SFXVol", out SFXVolPref);
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (isPaused && !PlayerLife.isDead)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        SetSound("SFXVol", -80);
        SetSound("musicVol", musicVolPref - 5);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        SetSound("SFXVol", SFXVolPref);
        SetSound("musicVol", musicVolPref);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void RestartGame()
    {
        SetSound("SFXVol", SFXVolPref);
        SetSound("musicVol", musicVolPref);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SetSound("SFXVol", SFXVolPref);
        SetSound("musicVol", musicVolPref);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title Screen");
    }
}
