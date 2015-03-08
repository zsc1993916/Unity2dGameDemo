using UnityEngine;
using System.Collections;

/*
 * Player的各种参数控制
 */

public class PlayerAbility : MonoBehaviour {

	public static PlayerAbility _instance;

	public float jumpSpeed;			// 跳起的速度
	public float runSpeed;			// 跑的速度

	public float slowDownTime;		// 减速持续时间
	public float speedUpTime;		// 加速持续时间
	public float jumpHigherTime;

	private bool isBeingSlowDown;

	// Use this for initialization
	void Start () {
		_instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	// 一下两个函数一起用 跳的更高，持续时间 speedUpTime
	public void JumpHigher()
	{
		StartCoroutine ("JumpHigherIE");
	}
	
	public IEnumerator JumpHigherIE()
	{
		float oldSpeed = jumpSpeed;
		jumpSpeed *= 1.2f;
		yield return new WaitForSeconds(jumpHigherTime);
		jumpSpeed = oldSpeed;
	}



	// 一下两个函数一起用 加速，持续时间 speedUpTime
	public void SpeedUp()
	{
		StartCoroutine ("SpeedUpIE");
	}
	
	public IEnumerator SpeedUpIE()
	{
		float oldSpeed = runSpeed;
		runSpeed *= 2.0f;
		yield return new WaitForSeconds(speedUpTime);
		runSpeed = oldSpeed;
	}



	// 一下两个函数一起用 减速，持续时间 slowDownTime
	public void SlowDown()
	{
		if(isBeingSlowDown == false)
			StartCoroutine ("SlowDownIE");
	}

	public IEnumerator SlowDownIE()
	{
		isBeingSlowDown = true;
		float oldSpeed = runSpeed;
		runSpeed /= 2.0f;
		yield return new WaitForSeconds(slowDownTime);
		runSpeed = oldSpeed;
		isBeingSlowDown = false;
	}
}
