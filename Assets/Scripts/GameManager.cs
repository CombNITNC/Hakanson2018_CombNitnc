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


	private float timer;

	// Use this for initialization
	void Start () {
		scriptMoneyManager = GetComponent<MoneyManager>();
		scriptVMManager = GameObject.Find("VMmain").GetComponent<VMManager>();
		scriptMoneyManager.ChangeMoney(100);

		timer = 100;
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
		DrawScore();
	}

	private void DrawTime(){
		int min = (int)timer / 60;
		int sec = (int)timer - (min*60);
		TextTime.text = "残り: " + min.ToString() + "分"  + sec.ToString() + "秒";
	}

	private void DrawScore(){
		TextScore.text = "あなたは　" + scriptVMManager.GetCount().ToString() + "本買った";
	}
}
