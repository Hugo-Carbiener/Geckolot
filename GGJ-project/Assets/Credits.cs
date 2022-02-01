using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        IEnumerator waitForScene()
        {
            yield return new WaitForSeconds(30);
            SceneManager.LoadScene(0);
        }

        StartCoroutine(waitForScene());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("LevelOne");
        }
    }
}
