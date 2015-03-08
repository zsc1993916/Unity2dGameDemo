using UnityEngine;
using System.Collections;

/*
 * 从上面才会触发的弹跳机关
 */

public class SpringController : MonoBehaviour {
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
			// 横着碰到不会触发效果
			if(Mathf.Abs(col.contacts[0].point.y - col.contacts[1].point.y) > 0.01f)
			{
				gameObject.collider2D.enabled = false;
			}
			else
				anim.SetBool("isSpring", true);
		}
	}
	
	// 离开碰撞
	public void OnCollisionExit2D(Collision2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			anim.SetBool("isSpring", false);
		}
	}
}
