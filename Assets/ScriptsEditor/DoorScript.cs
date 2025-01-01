using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool open;
    public bool enter;
    public bool audios;
    public AudioClip openAudio;
    public AudioClip closeAudio;
    public float smooth = 2.0f;
    public float doorOpenAngle = 90.0f;
    private Vector3 defaultRot;
    private Vector3 openRot;

    // Start is called before the first frame update
    void Start()
    {
        defaultRot = transform.eulerAngles;
        openRot = new Vector3(defaultRot.x, defaultRot.y + doorOpenAngle, defaultRot.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (enter)
        {
            open = true;
        }

        if (open)
        {
            if (audios == false)
            {
                GetComponent<AudioSource>().PlayOneShot(openAudio);
                audios = true;
            }
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
            
        }
        else
        {
            if (audios == true)
            {
                GetComponent<AudioSource>().PlayOneShot(closeAudio);
                audios = false;
            }
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);

        }
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "guest")
        {
            enter = true;
        }
    }

    private void OnTriggerExit(Collider obj)
    {
        if (obj.tag == "guest")
        {
            enter = false;
            open = false;
        }
    }
}
