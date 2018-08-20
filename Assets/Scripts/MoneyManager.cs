using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour {
	private int money;

	// Use this for initialization
	void Start () {
		money = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddMoney(int x){
		money += x;
	}

	public void ChangeMoney(int x){
		money = x;
	}

	public int GetMoney(){
		return money;
	}
}
