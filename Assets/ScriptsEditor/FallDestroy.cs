using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider obj)
    {
        Debug.Log("EnterFloor");
        if (obj.gameObject.tag == "ExcludeTeleport" || obj.gameObject.tag == "guest")
        {
            Invoke("destroyObject",3);
        }
        
    }

    private void destroyObject()
    {
        Destroy(gameObject);
    }
}
