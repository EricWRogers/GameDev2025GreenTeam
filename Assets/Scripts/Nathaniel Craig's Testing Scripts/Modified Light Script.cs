using UnityEngine;

public class ModifiedLightScript : MonoBehaviour
{
    public int thisTorchVal = 1;
    public MeshRenderer PLS;
    public GameObject activate;

    public void Start()
    {
        PLS.enabled = false;
    }
    private void Update()
    {
        if (activate.activeSelf == true)
        {
            PLS.enabled = true;
        }
        else
        {
            PLS.enabled = false;
        }
    }
}
