using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownLook : MonoBehaviour
{
    public Vector3 rotation = new Vector3(0, 0, 0);
    public float lookSpeed = 5f;
    // Update is called once per frame
    void Update()
    {
        rotation.z += Input.GetAxis("Mouse Y") * (lookSpeed / 2);
        transform.eulerAngles = rotation;
    }
}
