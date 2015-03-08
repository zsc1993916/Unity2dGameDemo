using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinsCounter : MonoBehaviour {

	public static CoinsCounter _instance;
	private int coinsCnt = 0;
	public Text text;

	// Use this for initialization
	void Start () {
		_instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = coinsCnt.ToString ();
	}

	public void GetCoin()
	{
		coinsCnt++;
	}
}
