using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableauManager : MonoBehaviour
{
    [SerializeField] private GameObject[] resetableObjects;
    [SerializeField] private GameObject attractorSpawnPoint;
    [SerializeField] private GameObject repulsorSpawnPoint;
    private GameManager gameManager;
    private int interruptorState = 0;
    public void ResetTableau()
    {
        foreach (var r in resetableObjects)
        {
            //resetableObjects.ResetObject();
            Debug.Log(r.name);
        }
    }

    public void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void Activate()
    {
        this.enabled = false;
    }

    public void Deactivate()
    {
        
    }

    public Vector2 GetAttractorSpawnPoint()
    {
        return this.attractorSpawnPoint.transform.position;
    }

    public Vector2 GetRepulsorSpawnPoint()
    {
        return this.repulsorSpawnPoint.transform.position;
    }

    public void interruptorOn()
    {
        interruptorState++;
        if (interruptorState == 2)
        {
            gameManager.NextTableau();
        }
    }

    public void interruptorOff()
    {
        interruptorState--;
    }

}
