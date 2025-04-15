using UnityEngine;
using TMPro;

public class StickyFingers : MonoBehaviour
{
    public int gold = 0;
    public TMP_Text scoreText;
    public TMP_Text winText;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pickup") {
            collision.gameObject.SetActive(false);
            gold += collision.gameObject.GetComponent<Pickup>().amount;
            scoreText.text = "Score: " + gold;

                winText.gameObject.SetActive(gold > 119);

            //gold++;
            // gold += 1;
            // gold = gold + 1;
        }
    }
}

