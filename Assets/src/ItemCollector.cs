using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TMP_Text cherriesTxt;
    [SerializeField] private AudioSource collectSFX;
    private int cherries = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cherry"))
        {
            Destroy(other.gameObject);

            cherries++;
            collectSFX.Play();
            cherriesTxt.SetText("Cherries: " + cherries);
        }
    }
}
