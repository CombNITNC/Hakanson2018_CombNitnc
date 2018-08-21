using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	private MoneyManager scriptMoneyManager;
	private VMManager scriptVMManager;
	[SerializeField] GameObject coin100;
	[SerializeField] GameObject coin10;
	[SerializeField] Text TextTime;
	[SerializeField] Text TextScore;
	[SerializeField] Text TextResidueCan;
	[SerializeField] Text TextLevel;
	[SerializeField] GameObject gameOverPrefab;
	[SerializeField] GameObject title;
	GameObject gameOver;
	private int[,] levelList = {
		{10,2},
		{10,3},
		{10,4},
		{10,5},
		{10,6},
		{10,7},
		{10,8},
		{10,9},
		{10,10},
		{10,11},
	};


	private float timer;
	private int noruma;
	private int level;
	public bool gameFlag;
	private bool titleFlag;

	// Use this for initialization
	void Start () {
		scriptMoneyManager = GetComponent<MoneyManager>();
		scriptVMManager = GameObject.Find("VMmain").GetComponent<VMManager>();
		scriptMoneyManager.ChangeMoney(100);
		gameFlag = false;
		titleFlag = true;
		level = 0;
		LevelUp();
		DrawTime();
	}
	
	// Update is called once per frame
	void Update () {	
		if(gameFlag) Run();

		if(!titleFlag){
			if(Input.GetKeyDown("r")){
				titleFlag = true;
				Destroy(gameOver);
				Instantiate(title, Vector2.zero, Quaternion.identity);
			}
		}
		// Debug お金を1000円に固定
		// moneyManagerScript.ChangeMoney(1000);
	}

	private void Run(){
		Random.Range(1,1);
		CoinIN();
		timer -= Time.deltaTime;
		DrawTime();
		ScoreManager();
	}

	private void CoinIN(){
		// Space入力で課金
		if(Input.GetKeyDown(KeyCode.Space)){
			if(Random.Range(0, 100) < 10) Instantiate(coin100, Vector2.zero, Quaternion.identity);
			else Instantiate(coin10, new Vector3(0,0,-5), Quaternion.identity);
		}
	}

	private void DrawTime(){
		int min = (int)timer / 60;
		int sec = (int)timer - (min*60);
		if(min == 0 && sec <= 0) GameOver();
		TextTime.text = "残り: " + min.ToString() + "分 "  + sec.ToString() + "秒";
	}

	private void ScoreManager(){
		int score = scriptVMManager.GetCount();
		int residue = noruma - score;

		if(residue == 0) LevelUp();

		TextScore.text = "あなたは: " + score.ToString() + "本買った";
		TextResidueCan.text = "残り: " + residue.ToString() + "本";
	}

	private void LevelUp(){
		scriptMoneyManager.ChangeMoney(0);
		level++;
		timer = levelList[level-1,0];
		noruma += levelList[level-1,1];

		TextLevel.text = "Level: "+ level.ToString();
	}

	private void GameOver(){
		gameFlag = false;
		titleFlag = false;
		gameOver = Instantiate(gameOverPrefab, Vector3.zero, Quaternion.identity) as GameObject;
	}

	public void GameStart(){
		gameFlag = true;
		level = 0;
		noruma = 0;
		LevelUp();
	}
}
