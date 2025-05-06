using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class PlayerUICoin : MonoBehaviour
{
    public TMP_Text counter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        counter.text = ("S " + GlobalVarsSetup.coincount.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        counter.text = ("$ " + GlobalVarsSetup.coincount.ToString());
    }
}
