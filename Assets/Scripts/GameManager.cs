using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	MoneyManager moneyManagerScript;

	// Use this for initialization
	void Start () {
		moneyManagerScript.ChangeMoney(0);
	}
	
	// Update is called once per frame
	void Update () {	
	}

	private void Run(){
		// Space入力で100円追加
		if(Input.GetKeyDown("space")){
			moneyManagerScript.AddMoney(100);
		}
	}
}
