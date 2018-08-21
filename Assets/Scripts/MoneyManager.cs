using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MoneyManager : MonoBehaviour {
	private int money;
	[SerializeField] private Text[] textMoney;

	// Use this for initialization
	void Start () {
		money = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddMoney(int x){
		money += x;
		Draw();
	}

	public void ChangeMoney(int x){
		money = x;
		Draw();
	}

	public int GetMoney(){
		return money;
	}

	private void Draw(){
		for(int i = 0; i< textMoney.Length; i++){	
			textMoney[i].text = "¥" + money.ToString();
		}
	}	
}
