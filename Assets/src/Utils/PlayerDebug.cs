using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDebug : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
