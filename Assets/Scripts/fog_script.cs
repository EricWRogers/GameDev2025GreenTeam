using UnityEngine;

public class fog_script : MonoBehaviour
{
    public GameObject torch;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (torch.activeSelf == true)
        {
            RenderSettings.fogDensity = 0.2f;
        }
        else if (torch.activeSelf == false)
        {
            RenderSettings.fogDensity = 0.3f;
        }

    }
}
