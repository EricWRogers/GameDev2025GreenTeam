using UnityEngine;

public class Dissapear : MonoBehaviour
{
    private int disa = 1;

    // Update is called once per frame
    void Update()
    {
        if (GlobalVarsSetup.coincount >= disa)
        {
            gameObject.SetActive(false);
        }
    }
}
