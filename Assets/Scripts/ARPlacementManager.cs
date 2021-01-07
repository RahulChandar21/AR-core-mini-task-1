using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;


public class ARPlacementManager : MonoBehaviour
{
    ARRaycastManager aRRaycastManager;
    ARPlaneManager aRPlaneManager;

    static List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

    public Camera aRCamera;

    private int i = 0;

    public GameObject cubeSpawnButton;
    public GameObject resetButton;
    public GameObject[] cubePrefab;
    public GameObject scaleSlider;

    void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        aRPlaneManager = GetComponent<ARPlaneManager>();

        resetButton.SetActive(false);
        scaleSlider.SetActive(true);
    }

    void Update()
    {
        
    }

    public void PlaceCube()
    {
        if(i < cubePrefab.Length)
        {
            //Ray sent out from midpoint of the modible screen/camera.
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2);
            Ray ray = aRCamera.ScreenPointToRay(screenCenter);

            //Executes when ray intersects with detected plane.
            if (aRRaycastManager.Raycast(ray, hitResults, TrackableType.PlaneWithinPolygon))
            {
                //To get pose of the plane that was hit by raycast.
                Pose planeHitPose = hitResults[0].pose;

                //Position of the hit plane.
                Vector3 positionToPlace = planeHitPose.position;

                cubePrefab[i].transform.position = positionToPlace;

                i = i + 1;

                //To deactivate cube spawn button, when all cubes have been spwaned.
                if(i == cubePrefab.Length)
                {
                    cubeSpawnButton.SetActive(false);
                    resetButton.SetActive(true);
                    scaleSlider.SetActive(false);

                    //To disable tracked plane visualization once all cubes are spwaned.
                    foreach (var plane in aRPlaneManager.trackables)
                    {
                        plane.gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    public void ResetCubes()
    {
        i = 0;

        //Reset position of the cubes (Away from user field of view).
        for (int j = 0; j < cubePrefab.Length; j++)
        {
            cubePrefab[j].transform.position = new Vector3(0, 10, 0);
        }

        cubeSpawnButton.SetActive(true);
        resetButton.SetActive(false);
        scaleSlider.SetActive(true);

        //To enable tracked plane visualization again.
        foreach (var plane in aRPlaneManager.trackables)
        {
            plane.gameObject.SetActive(true);
        }
    }
}
