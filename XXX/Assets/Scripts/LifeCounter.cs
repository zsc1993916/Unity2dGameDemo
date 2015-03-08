using UnityEngine;
using System.Collections;

public class LifeCounter : MonoBehaviour {

	public static LifeCounter _instance;
	public GameObject[] lifeCounter;
	private int hp = 5;

	// Use this for initialization
	void Start () {
		_instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GetAttack()
	{
		if(hp == 0) return;
		hp--;
		Destroy (lifeCounter [hp]);
	}
}
