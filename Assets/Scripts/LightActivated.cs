using UnityEngine;

public class LightActivated : MonoBehaviour
{
    public int thisTorchVal = 1;
    public MeshRenderer PLS;

    public void Start()
    {
        PLS.enabled = false;
    }
    private void Update()
    {
        if (GlobalVarsSetup.torchCode == thisTorchVal)
        {
            PLS.enabled = true;
        }
        else
        {
            PLS.enabled = false;
        }
    }
}
