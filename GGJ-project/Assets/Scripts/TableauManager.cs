using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableauManager : MonoBehaviour
{
    [SerializeField] private GameObject[] resetableObjects;
    [SerializeField] private GameObject attractorSpawnPoint;
    [SerializeField] private GameObject repulsorSpawnPoint;
    public void ResetTableau()
    {
        foreach (var r in resetableObjects)
        {
            //resetableObjects.ResetObject();
            Debug.Log(r.name);
        }
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
}
