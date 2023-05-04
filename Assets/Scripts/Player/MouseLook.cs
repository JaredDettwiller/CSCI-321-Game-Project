using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Vector2 rotation = new Vector2(0, 0);
    public float lookSpeed = 10f;
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
            //rotation.x += Input.GetAxis("Mouse Y") * (lookSpeed / 2);
            transform.eulerAngles = rotation;
        }
    }
}
