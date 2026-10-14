using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Diagnostics;

public class CameraController : MonoBehaviour
{
    public List<GameObject> cameras;

    public int currentCameraIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(var camera in cameras)
        {
            camera.gameObject.SetActive(false);
        }
        if (cameras.Count > 0)
        {
            cameras[currentCameraIndex % cameras.Count].gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.cKey.wasPressedThisFrame && cameras.Count > 0)
        {
            UnityEngine.Debug.Log("C Pressed!");

            cameras[currentCameraIndex % cameras.Count].gameObject.SetActive(false);

            currentCameraIndex++;

            UnityEngine.Debug.Log(currentCameraIndex);

            cameras[currentCameraIndex % cameras.Count].gameObject.SetActive(true);
        }
        
    }
}
