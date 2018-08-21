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

	private int[,] levelList = {
		{100,2},
		{100,3},
		{100,4},
		{100,2},
		{100,3},
		{100,4},
	};


	private float timer;
	private int noruma;
	private int level;

	// Use this for initialization
	void Start () {
		scriptMoneyManager = GetComponent<MoneyManager>();
		scriptVMManager = GameObject.Find("VMmain").GetComponent<VMManager>();
		scriptMoneyManager.ChangeMoney(100);

		level = 0;
		LevelUp();
		DrawTime();
	}
	
	// Update is called once per frame
	void Update () {	
		Run();
		
		// Debug お金を1000円に固定
		// moneyManagerScript.ChangeMoney(1000);
	}

	private void Run(){
		Random.Range(1,1);
		// Space入力で課金
		if(Input.GetKeyDown(KeyCode.Space)){
			if(Random.Range(0, 100) < 10) Instantiate(coin100, Vector2.zero, Quaternion.identity);
			else Instantiate(coin10, Vector2.zero, Quaternion.identity);
		}

		timer -= Time.deltaTime;
		DrawTime();
		ScoreManager();
	}

	private void DrawTime(){
		int min = (int)timer / 60;
		int sec = (int)timer - (min*60);
		TextTime.text = "残り: " + min.ToString() + "分"  + sec.ToString() + "秒";
	}

	private void ScoreManager(){
		int score = scriptVMManager.GetCount();
		int residue = noruma - score;

		if(residue == 0) LevelUp();

		TextScore.text = "あなたは: " + score.ToString() + "本買った";
		TextResidueCan.text = "残り: " + residue.ToString() + "本";
	}

	private void LevelUp(){
		level++;
		timer = levelList[level-1,0];
		noruma += levelList[level-1,1];

		TextLevel.text = "Level: "+ level.ToString();
	}
}
