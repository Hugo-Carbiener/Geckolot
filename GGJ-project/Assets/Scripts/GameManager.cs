using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Timers;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public PlayerController attractor;
    public PlayerController repulsor;
    public Camera camera;
    public TableauManager currentTableauManager;

    public TableauManager[] tableauList;
    private int tableauIndex;

    public float cameraTransitionDuration;

    public DateTime chronometer;
    
    public void ResetProcedure()
    {
        //the coroutine FaderReset() MUST be called by a singular instance (GameManager for ex)
        StartCoroutine(FaderReset()); 
        attractor.ResetPlayer(currentTableauManager.GetAttractorSpawnPoint());
        repulsor.ResetPlayer(currentTableauManager.GetRepulsorSpawnPoint());
        currentTableauManager.ResetTableau();
        chronometer = new DateTime();
    }

    public void NextTableau()
    {
        TableauManager nextTableauManager = tableauList[tableauIndex + 1];
        nextTableauManager.enabled = true;
        StartCoroutine(CameraTransition(nextTableauManager));
        currentTableauManager.enabled = false;
        currentTableauManager = nextTableauManager;
        tableauIndex++;
    }

    // private void CameraTransition(TableauManager nextTableauManager)
    // {
    //     //camera.position
    // }

    IEnumerator CameraTransition(TableauManager nextTableauManager)
    {
        float timeElapsed = 0;
        Vector3 cameraStartPoint = new Vector3(currentTableauManager.transform.position.x,
            currentTableauManager.transform.position.y, camera.transform.position.z);
        Vector3 cameraEndPoint = new Vector3(nextTableauManager.transform.position.x,
            nextTableauManager.transform.position.y, camera.transform.position.z);
        Debug.Log("Moving from "+cameraStartPoint+" to "+cameraEndPoint);
        while (timeElapsed < cameraTransitionDuration)
        {
            camera.transform.position = Vector3.Lerp(cameraStartPoint, 
                cameraEndPoint, timeElapsed / cameraTransitionDuration);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        camera.transform.position = cameraEndPoint;
    }
    
    //this function will launch the fading process
    private IEnumerator FaderReset()
    {
        GameObject.FindGameObjectWithTag("Fader").GetComponent<FaderController>().LaunchFadeIn();
        yield return new WaitForSeconds(1f);
        GameObject.FindGameObjectWithTag("Fader").GetComponent<FaderController>().LaunchFadeOut();
    }

    public void Start()
    {
        currentTableauManager = tableauList[0];
        tableauIndex = 0;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            StartCoroutine(CameraTransition(tableauList[tableauIndex+1]));
            tableauIndex++;
            currentTableauManager = tableauList[tableauIndex];
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(FaderReset());
        }

        if(Input.GetKeyDown(KeyCode.R)){
            ResetProcedure();
        }
    }
}

