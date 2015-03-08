using UnityEngine;
using System.Collections;

public class GhostController : MonoBehaviour {

	public GameObject DieAnim;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void OnTriggerEnter2D(Collider2D col)
	{	

		if(col.tag == "Weapon") 
		{
			//被武器攻击 死亡
			GameObject.Destroy(gameObject);
			//gameObject.renderer.enabled = false;
			Instantiate(DieAnim, transform.position, transform.rotation);
		}
		if(col.tag == "Player") 
		{
			Debug.Log("Player");
		}
	}
}
