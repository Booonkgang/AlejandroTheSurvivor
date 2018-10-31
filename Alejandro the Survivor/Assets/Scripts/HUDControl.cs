using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HUDControl : MonoBehaviour {
    public Slider hpSilder;
	public float restart = 10f;
	public static uint currEnemyAmount;
	public Text GameComplete;
	public Text GameStart;
	public static uint totalEnemyAmount = 10;

	GameObject player;
    PlayerHealth playerHealth;
    Animator anim;
	float currTimer;
	float delayTimer;
	bool startFlag;
	bool resetFlag;
	public static bool endFlag;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		Time.timeScale = 1.0f;
		currEnemyAmount = 0;
		startFlag = true;
		resetFlag = true;
		endFlag = false;
		currTimer = 0;
		delayTimer = 0;
        player = GameObject.FindGameObjectWithTag("AstronautPlayer");
        playerHealth = player.GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
        hpSilder.value = playerHealth.currentHealth;
		if (startFlag) {	// Help message when scene start
			var temp = GameStart.color;
			temp.a = 1f;
			GameStart.color = temp;

			Time.timeScale = 0;
			currTimer += Time.unscaledDeltaTime;

			if (currTimer >= restart) {
				Time.timeScale = 1.0f;
				temp = GameStart.color;
				temp.a = 0;
				GameStart.color = temp;

				currTimer = 0;
				startFlag = false;
			}
		} else if (playerHealth.currentHealth <= 0) {	// Game Over message control
			anim.SetTrigger ("GameOver");
		
			currTimer += Time.deltaTime;

			if (currTimer >= restart) {
				SceneManager.LoadScene ("GameMenuScene");
			}
		} else if (currEnemyAmount >= totalEnemyAmount || anim.GetInteger("parts") >= 3) {	// Scene complete message control
			var temp = GameComplete.color;
			temp.a = 1f;
			GameComplete.color = temp;

			delayTimer += Time.unscaledDeltaTime;

			if (delayTimer >= 1.0f) {
				Time.timeScale = 0;

				currTimer += Time.unscaledDeltaTime;

				if (currTimer >= restart) {
                    SceneManager.LoadScene ("GameMenuScene");
				}
			}
		}

	}

	// Switch between different scene for future use
	private void SceneSelect(string sceneName){
		if (sceneName == "Level1") {
			SceneManager.LoadScene ("Level2");
		} else if (sceneName == "Level2") {
			SceneManager.LoadScene ("Level3");
		} else if (sceneName == "Level3") {
			//SceneManager.LoadScene ("Level1");
			Application.Quit();
		} else {
			
		}
	}
}