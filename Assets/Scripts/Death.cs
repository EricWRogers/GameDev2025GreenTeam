using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter(Collider player)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Ded Screne");
    }
}
