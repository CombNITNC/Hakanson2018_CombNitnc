using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VMManager : MonoBehaviour {
	private MoneyManager moneyManagerScript;

	[SerializeField] private GameObject[] canList;
	[SerializeField] private Text[] keyText;
	private GameObject canEntryPoint;
	private int num_q;

	private struct Can {
		public string key;
		public int price;

		public Can(string k, int p){
			key = k;
			price = p;
		}
	}

	Can[] product = new Can[4];

	// Use this for initialization
	void Start () {
		moneyManagerScript = GameObject.Find("GameManager").GetComponent<MoneyManager>();
		canEntryPoint = GameObject.Find("CanEntryPoint");

		product[0] = new Can("a", 130);
		product[1] = new Can("s", 100);
		product[2] = new Can("d", 200);
		product[3] = new Can("f", 160);


		SetProduct();
	}
	
	// Update is called once per frame
	void Update () {
		// 指定キーの入力で商品を購入
		if(Input.GetKeyDown(product[num_q].key)){
			if(moneyManagerScript.GetMoney() >= product[num_q].price) {
				moneyManagerScript.AddMoney(-product[num_q].price);
				Instantiate(canList[num_q], canEntryPoint.transform.position, Quaternion.identity);
				SetProduct();
			}
		}
	}
	
	private void  SetProduct(){
		// 購入キーの設定
		num_q= Random.Range(0,product.Length);

		// 表示
		for(int i = 0; i < keyText.Length; i++){
			keyText[i].text = "Press " + product[num_q].key + "\n¥" + product[num_q].price;
		}
	}
}
