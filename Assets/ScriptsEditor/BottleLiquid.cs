using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleLiquid : MonoBehaviour
{
    public ParticleSystem particleLauncher;

    // Start is called before the first frame update
    void Start()
    {
        particleLauncher.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider obj)
    {
        if (obj.tag == "Pan")
        {
            particleLauncher.Play();
        } 
    }

    
}
