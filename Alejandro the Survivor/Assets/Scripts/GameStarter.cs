using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //Application.LoadLevel(0);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        //        Debug.Log("Start Main Scene");
        Debug.Log("Hello World");
        SceneManager.LoadScene("MarsLevel1");
    }

}
