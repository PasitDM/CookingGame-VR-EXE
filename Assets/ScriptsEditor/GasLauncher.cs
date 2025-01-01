using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasLauncher : MonoBehaviour
{
    public ParticleSystem particleLauncher;
    GameObject objDes;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Pan")
        {
            Debug.Log("BUTTON GAS STOVE");
            Destroy(objDes);
        }
    }

    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
