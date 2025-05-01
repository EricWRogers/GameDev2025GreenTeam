using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public bool isStart;
    public bool isQuit;
    // Called when we click the "Play" button.
    public void OnMouseUp()
    {
        if (isQuit)
        {
            Application.Quit();
        }
        if (isStart)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("THE GAME");
        }
    }
}