using UnityEngine;
using System.Collections;

public class CameraOrbit : MonoBehaviour
{

    private Transform _XForm_Camera;
    private Transform _XForm_Parent;

    private Vector3 _LocalRotation;
    private float _CameraDistance = 5f;

    private float MouseSensitivity = 1f;
    private float ScrollSensitvity = 2f;
    private float OrbitDampening = 10f;
    private float ScrollDampening = 6f;

    private bool CameraDisabled = false;


    // Use this for initialization
    void Start()
    {
        this._XForm_Camera = this.transform;
        this._XForm_Parent = this.transform.parent;
    }


    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            CameraDisabled = !CameraDisabled;

        if (!CameraDisabled)
        {
            //Rotation of the Camera based on Mouse Coordinates
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                _LocalRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
                _LocalRotation.y += Input.GetAxis("Mouse Y") * MouseSensitivity;

                //Clamp the y Rotation to horizon and not flipping over at the top
                if (_LocalRotation.x < -50f)
                    _LocalRotation.x = -50f;
                else if (_LocalRotation.x > 50)
                    _LocalRotation.x = 50;

                if (_LocalRotation.y < 0f)
                    _LocalRotation.y = 0f;
                else if (_LocalRotation.y > 45)
                    _LocalRotation.y = 45;
            }
            //Zooming Input from our Mouse Scroll Wheel
            if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitvity;

                ScrollAmount *= (this._CameraDistance * 0.3f);

                this._CameraDistance += ScrollAmount * -1f;

                this._CameraDistance = Mathf.Clamp(this._CameraDistance, 1.5f, 100f);

                if (this._CameraDistance < 3f)
                    this._CameraDistance = 3f;
                else if (this._CameraDistance > 7f)
                    this._CameraDistance = 7f;

            }
        }

        //Actual Camera Rig Transformations
        Quaternion QT = Quaternion.Euler(_LocalRotation.y, _LocalRotation.x, 0);

        this._XForm_Parent.rotation = Quaternion.Lerp(this._XForm_Parent.rotation, QT, Time.deltaTime * OrbitDampening);

        if (this._XForm_Camera.localPosition.z != this._CameraDistance * -1f)
        {
            this._XForm_Camera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this._XForm_Camera.localPosition.z, this._CameraDistance * -1f, Time.deltaTime * ScrollDampening));
        }
    }
}