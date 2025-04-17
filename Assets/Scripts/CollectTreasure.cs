using UnityEngine;
using TMPro;

public class StickyFingers : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text winText;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pickup") {
            collision.gameObject.SetActive(false);
            scoreText.text = "Score: " + GlobalVarsSetup.coincount;

                winText.gameObject.SetActive(GlobalVarsSetup.coincount > 119);

            //gold++;
            // gold += 1;
            // gold = gold + 1;
        }
    }
}

