using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Cinemachine;

public class CameraController : MonoBehaviour
{
    public List<CinemachineVirtualCameraBase> cameras;

    public int currentCameraIndex = 0;

    //define player controller to use
    public MainPlayerController playerController;
    //define game manager to use



    //camera intro duration
    [SerializeField] private float worldPanDuration = 15f;
    [SerializeField] private float playerZoomDuration = 8f;
    [SerializeField] private float targetZoomDuration = 10f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // UNCOMMENT IF EVER USE MULTIPLE CAMERAS BY CLICKING ONE KEY AGAIN

        //UnityEngine.Debug.Log("Camera Count: " + cameras.Count);

        //foreach (var camera in cameras)
        //{
        //    camera.gameObject.SetActive(false);
        //}
        //if (cameras.Count > 0)
        //{
        //    cameras[currentCameraIndex % cameras.Count].gameObject.SetActive(true);
        //}


        //calls coroutine for camera animations
        StartCoroutine(playCamerasStart());


    }

    //coroutine to switch between camera animations
    private IEnumerator playCamerasStart()
    {
        //disables player controller so user doesnt move while the animation goes
        playerController.enabled = false;

        //Disable all cameras
        foreach(var camera in cameras)
        {
            camera.gameObject.SetActive(false);
        }

        //World Pan active 
        cameras[0].gameObject.SetActive(true);
        yield return new WaitForSeconds(worldPanDuration);
        cameras[0].gameObject.SetActive(false); //de-activate world pan camera

        //Player zoom active 
        cameras[1].gameObject.SetActive(true);
        yield return new WaitForSeconds(playerZoomDuration);
        cameras[1].gameObject.SetActive(false); //de-activate player zoom camera

        //Target zoom active
        cameras[2].gameObject.SetActive(true);
        yield return new WaitForSeconds(targetZoomDuration);
        cameras[2].gameObject.SetActive(false); //de-activate target zoon camera


        //Gameplay camera active (will be the only one staying active after)
        cameras[3].gameObject.SetActive(true);

        playerController.enabled = true; //controller comes back to work

        GameManager gameManager = FindAnyObjectByType<GameManager>();

        if (gameManager != null)
        {
            gameManager.StartTimer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // UNCOMMENT IF EVER USE MULTIPLE CAMERAS BY CLICKING ONE KEY AGAIN

        //if(Keyboard.current.cKey.wasPressedThisFrame && cameras.Count > 0)
        //{
        //    UnityEngine.Debug.Log("C Pressed!");

        //    cameras[currentCameraIndex % cameras.Count].gameObject.SetActive(false);

        //    currentCameraIndex++;

        //    UnityEngine.Debug.Log(currentCameraIndex);

        //    cameras[currentCameraIndex % cameras.Count].gameObject.SetActive(true);
        //}




    }
}
