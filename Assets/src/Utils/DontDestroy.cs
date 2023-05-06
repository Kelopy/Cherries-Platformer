using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public bool destroy;

    private void Awake()
    {
        if (!destroy)
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("BGM");
            if (objs.Length > 1)
                Destroy(this.gameObject);

            DontDestroyOnLoad(this.gameObject);
        }
    }
}
