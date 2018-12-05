using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour
{
    public float restart;
    public Text Text1;
    public Text Text2;
    public CanvasGroup panelGroup;
    public CanvasGroup introGroup;
    bool startFlag = false;
    bool text1Flag = false;
    float currTimer;
    //public ;

    // Use this for initialization
    void Start()
    {
        //Application.LoadLevel(0);
        restart = 10.0f;
        currTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (startFlag && !text1Flag)
        {
            currTimer += Time.unscaledDeltaTime;
            if (currTimer >= restart)
            {
                text1Flag = true;
                currTimer = 0.0f;
            }
        }
        if (text1Flag)
        {
            var temp = Text1.color;
            temp.a = 0.0f;
            Text1.color = temp;
            temp.a = 1.0f;
            Text2.color = temp;
            currTimer += Time.unscaledDeltaTime;
            if (currTimer >= restart)
            {
                SceneManager.LoadScene("MarsLevel1");
            }
        }
    }

    public void StartGame()
    {
        startFlag = true;
        panelGroup.alpha = 0.0f;
        introGroup.alpha = 1.0f;
    }

}
