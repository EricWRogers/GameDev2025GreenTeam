using UnityEngine;
using TMPro;
using Unity.Collections;

public class GoldCount : MonoBehaviour
{

    public TMP_Text Gold;


    // Update is called once per frame
    void Update()
    {
        Gold.text = "Gold: " + GlobalVarsSetup.coincount;
    }
}
