using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using EBC.Player.Controller.Core;

public class XRCardboardMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] XRCardboardInputSettings settings = default;
    private int key_ws, key_ad;
    public int keyWS {
        set {
            key_ws = value;
        }
    } 
    
    private Transform xrRigTransform;
    private Transform xrCamTransform;

    // Update is called once per frame
    void Awake(){
        xrRigTransform = GetComponent<Transform>();
        xrCamTransform = GetComponent<XrManager>().xrCam.GetComponent<Transform>();
        if (xrCamTransform == null) Debug.Log("CameraTransform in xrManager is empty.",this);
    }
    void FixedUpdate()
    {
        if (Input.GetButton(settings.ClickInput) || (Input.touchCount ==2)){
            keyWS = 1;
        }
        else keyWS = 0;
        
        xrRigTransform.position += (Vector3.Scale(xrCamTransform.forward, new Vector3(1f,0f,1f)).normalized
            *key_ws*settings.forwardSpeed 
            + xrCamTransform.right * key_ad * settings.sideSpeed)
            *Time.deltaTime;
        
    }
}
