using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csCameraCtrl : MonoBehaviour {

    public float rotSpeed;
    private float MouseX;
    private Transform PlayerTransform;
    private Transform CamTransform;

    void Start()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        CamTransform = this.transform;
    }

    void Update ()
    {
        CamTransform.position = PlayerTransform.position;

        MouseX = Input.GetAxis("Mouse X");

        if(Input.GetMouseButton(1))
        {
            Vector3 vec = Vector3.up * MouseX;
            this.transform.Rotate(vec * rotSpeed * Time.deltaTime);
        }
    }
}
