using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Timers;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public PlayerController attractor;
    public PlayerController repulsor;
    public Camera camera;
    public TableauManager currentTableauManager;

    public TableauManager[] tableauList;
    private int tableauIndex;

    public float transitionDuration;

    public DateTime chronometer;

    [SerializeField] public TextWriter textWriter;

    public void Awake()
    {
        textWriter = FindObjectOfType<TextWriter>();
    }

    public void ResetProcedure()
    {
        //the coroutine FaderReset() MUST be called by a singular instance (GameManager for ex)
        setPlayersControllable(false);
        StartCoroutine(FaderReset());
    }

    public void NextTableau()
    {
        if (tableauIndex == tableauList.Length-1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            return;
        }
        else
        {
            TableauManager nextTableauManager = tableauList[tableauIndex + 1];
            nextTableauManager.enabled = true;
            StartCoroutine(ITableauTransition(nextTableauManager));
            currentTableauManager.enabled = false;
            currentTableauManager = nextTableauManager;
            tableauIndex++;
        }
    }

    public void setPlayersControllable(bool val)
    {
        attractor.SetControllable(val);
        attractor.gameObject.GetComponent<Attractor>().setPowerUsable(val);
        repulsor.SetControllable(val);
        repulsor.gameObject.GetComponent<Repulsor>().setPowerUsable(val);
    }

    IEnumerator ITableauTransition(TableauManager nextTableauManager)
    {
        float timeElapsed = 0;
        Vector3 cameraStartPoint = new Vector3(currentTableauManager.transform.position.x,
            currentTableauManager.transform.position.y, camera.transform.position.z);
        Vector3 cameraEndPoint = new Vector3(nextTableauManager.transform.position.x,
            nextTableauManager.transform.position.y, camera.transform.position.z);
        Debug.Log("Moving from "+cameraStartPoint+" to "+cameraEndPoint);
        
        var attractorStartPoint = (Vector2) attractor.gameObject.transform.position; 
        var attractorEndPoint = nextTableauManager.GetAttractorSpawnPoint();
        
        var repulsorStartPoint = (Vector2) repulsor.gameObject.transform.position;
        Vector2 repulsorEndPoint = nextTableauManager.GetRepulsorSpawnPoint();
        
        //On retire le contrôle aux joueurs, puis on les met en animation de course pour se déplacer vers le
        //spawn du tableau suivant. 
        setPlayersControllable(false);
        attractor.startAnimation("is_running");
        repulsor.startAnimation("is_running");
        while (timeElapsed < transitionDuration)
        {
            attractor.transform.position = Vector2.Lerp(attractorStartPoint, attractorEndPoint,
                timeElapsed / transitionDuration);
            repulsor.transform.position = Vector2.Lerp(repulsorStartPoint, repulsorEndPoint,
                timeElapsed / transitionDuration);
            camera.transform.position = Vector3.Lerp(cameraStartPoint, 
                cameraEndPoint, timeElapsed / transitionDuration);
            timeElapsed += Time.deltaTime;

            yield return null;
        }
        
        camera.transform.position = cameraEndPoint;
        repulsor.transform.position = repulsorEndPoint;
        attractor.transform.position = attractorEndPoint;
        repulsor.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        attractor.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        attractor.startAnimation("is_idle");
        repulsor.startAnimation("is_idle");
        //START DIALOGUE
        Debug.Log("Dans la coroutine");
        try
        {
            textWriter.ActivateDialogue();
        }
        catch (IndexOutOfRangeException e)
        {
            Debug.LogError(e.StackTrace);
        }
        //STOP DIALOGUE : on relâche les joueurs 
        //Les joueurs sont rélâchés dans la méthode AddText de TextWriter
    }
    
    //this function will launch the fading process
    private IEnumerator FaderReset()
    {
        FaderController fader = GameObject.FindGameObjectWithTag("Fader").GetComponent<FaderController>();
        fader.LaunchFadeIn();
        yield return new WaitForSeconds(fader.fadeDuration);
        attractor.ResetPlayer(currentTableauManager.GetAttractorSpawnPoint());
        repulsor.ResetPlayer(currentTableauManager.GetRepulsorSpawnPoint());
        fader.LaunchFadeOut();
        yield return new WaitForSeconds(fader.fadeDuration);
        Debug.Log("Attractor velocity : "+attractor.rb.velocity+" | Repulsor velocity : "+repulsor.rb.velocity);
        currentTableauManager.ResetTableau();
        chronometer = new DateTime();
        setPlayersControllable(true);
    }

    public void Start()
    {
        currentTableauManager = tableauList[0];
        tableauIndex = 0;
    }

    /*
     * Fonction qui n'a aucune utilité autre que de tester rapidement des fonctions à l'aide de raccourcis.
     * Tout peut yeet à tout moment !
     */
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            // StartCoroutine(ITableauTransition(tableauList[tableauIndex+1]));
            // tableauIndex++;
            // currentTableauManager = tableauList[tableauIndex];
            NextTableau();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(FaderReset());
        }

        if(Input.GetKeyDown(KeyCode.R)){
            ResetProcedure();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("is_running");
            repulsor.startAnimation("is_running");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("is_jumping");
            repulsor.startAnimation("is_jumping");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("isGrounded");
            repulsor.startAnimation("isGrounded");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("is_idle");
            repulsor.startAnimation("is_idle");
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("is_falling");
            repulsor.startAnimation("is_falling");
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Debug.Log("is_tumbling");
            repulsor.startAnimation("is_tumbling");
        }
        
        
    }
}

