using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VMManager : MonoBehaviour {
	private MoneyManager moneyManagerScript;

	[SerializeField] private GameObject[] canList;
	[SerializeField] private Text[] keyText;
	private GameObject canEntryPoint;
	private string[] keys = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};
	private int[] priceList = {100, 120, 130, 150, 160 ,200};
	private int num_q;
	private int price;
	private GameObject can;

	// Use this for initialization
	void Start () {
		moneyManagerScript = GameObject.Find("GameManager").GetComponent<MoneyManager>();
		canEntryPoint = GameObject.Find("CanEntryPoint");
		SetProduct();
	}
	
	// Update is called once per frame
	void Update () {
		// 指定キーの入力で商品を購入
		if(Input.GetKeyDown(keys[num_q])){
			if(moneyManagerScript.GetMoney() >= price) {
				moneyManagerScript.AddMoney(-price);
				Instantiate(can, canEntryPoint.transform.position, Quaternion.identity);
				SetProduct();
			}
		}
	}
	
	private void  SetProduct(){
		// 購入キーの設定
		num_q= Random.Range(0,keys.Length);

		// 商品の金額設定
		price = priceList[Random.Range(0,priceList.Length)];

		// 商品の種類を設定
		can = canList[Random.Range(0, canList.Length)];

		// 表示
		for(int i = 0; i < keyText.Length; i++){
			keyText[i].text = "Press " + keys[num_q] + "\n¥" + price;
		}
	}
}
