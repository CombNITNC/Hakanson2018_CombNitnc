using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VMManager : MonoBehaviour {
	MoneyManager moneyManagerScript;

	// Use this for initialization
	void Start () {
		moneyManagerScript = GameObject.Find("GameManager").GetComponent<MoneyManager>();
	}
	
	// Update is called once per frame
	void Update () {
		// 指定キーの入力で商品を購入
		if(Input.GetKeyDown(KeyCode.A)){
			if(moneyManagerScript.GetMoney() > 100) moneyManagerScript.AddMoney(-100);
		}
	}
}
