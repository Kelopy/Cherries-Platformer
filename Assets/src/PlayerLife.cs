using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private AudioSource deathSFX;
    [SerializeField] private int deathZone = -19;
    private Rigidbody2D rb2d;
    private Animator anim;
    public static bool isDead;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (transform.position.y <= deathZone && !isDead)
        {
            Death();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            Death();
        }
    }

    private void Death()
    {
        gameOverMenu.SetActive(true);
        rb2d.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        deathSFX.Play();
        isDead = true;
    }
}
