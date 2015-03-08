using UnityEngine;
using System.Collections;

/*
 * 控制状态机来播放摇晃动画
 */

public class BoardController : MonoBehaviour {
	
	private Animator anim;			// 状态机
	
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();			// 状态机
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	// 开始碰撞 
	public void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			anim.SetBool("isBeginTouch", true);
		}
	}

	// 播放完动画时 在动画里调用
	public void BeginTouchAnimOver()
	{
		anim.SetBool("isBeginTouch", false);
	}
}
