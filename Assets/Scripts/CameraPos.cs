using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour {

   
    public Camera MainCamera;

    public void CameraStart()
    {
        MainCamera.transform.localPosition = new Vector3(-2.51f, 59.6f, -55.5f);
        MainCamera.transform.localEulerAngles = new Vector3(45, 0, 0);
    }
    public void CameraLar01()
    {
        MainCamera.transform.localPosition = new Vector3(-0.609219f, 57.42095f, -33.99646f);
        MainCamera.transform.localEulerAngles = new Vector3(45, 0, 0);
    }
     public void CameraLar02()
    {
        MainCamera.transform.localPosition = new Vector3(-1.907307f, 51.41456f, -28.6411f);
        MainCamera.transform.localEulerAngles = new Vector3(45, 0, 0);
    }
    public void CameraLar03()
     {
        MainCamera.transform.localPosition = new Vector3(-1.373165f, 39.81329f, -28.48963f);
        MainCamera.transform.localEulerAngles = new Vector3(45, 0, 0);

    }
    public void CameraLar04()
     {
        MainCamera.transform.localPosition = new Vector3(-3.961029f, 36.86295f, -30.51594f);
        MainCamera.transform.localEulerAngles = new Vector3(45, 0, 0);

    }
    public void CameraLar05()
     {
        MainCamera.transform.localPosition = new Vector3(-3.576139f, 30.79122f, -28.52405f);
        MainCamera.transform.localEulerAngles = new Vector3(45, 0, 0);
    }
    public void CameraLar06()
     {
        MainCamera.transform.localPosition = new Vector3(-0.5381148f, 25.74456f, -24.49477f);
        MainCamera.transform.localEulerAngles = new Vector3(45, 0, 0);

    }
     public void CameraLar07()
     {
        MainCamera.transform.localPosition = new Vector3(-1.963728f, 21.37009f, -24.30225f);
        MainCamera.transform.localEulerAngles = new Vector3(45, 0, 0);

    }
    public void CameraLar08()
    {
        MainCamera.transform.localPosition = new Vector3(-2.602745f, 16.02305f, -23.46518f);
        MainCamera.transform.localEulerAngles = new Vector3(45, 0, 0);

    }
    
}
