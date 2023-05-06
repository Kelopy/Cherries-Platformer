using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLogic : MonoBehaviour
{
    private AudioSource finishSFX;
    private bool levelFinished;

    private void Start()
    {
        finishSFX = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && !levelFinished)
        {
            finishSFX.Play();
            levelFinished = true;
            Invoke("FinishLevel", 2f);
        }
    }

    private void FinishLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Debug.Log("Game Over.");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
