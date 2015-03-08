using UnityEngine;
using System.Collections;

/*
 *  Snake Controller
 * 	idle时在活动半径内左右移动
 * 	player进入攻击范围时追随
 *  超出范围返回活动范围
 */
public class SnakeController : MonoBehaviour {

	// 活动半径
	public float size = 5f;
	// 移动速度
	public float velocity = 0.7f;

	//移动方向 和 速度(vector)
	private float moveDirection = 1;
	private Vector3 vecVelocity;

	//player的transform
	private Transform player;

	// x左右端点
	private float leftX;
	private float rightX;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		leftX = transform.position.x - size;
		rightX = transform.position.x + size;
		vecVelocity = velocity * Vector3.right;
	}
	
	// Update is called once per frame
	void Update () {
		//如果player进入活动范围
		if( player.position.x >= leftX && player.position.x <= rightX ) {
			vecVelocity = 2 * velocity * Vector3.right;
			if(player.position.x < transform.position.x-0.3) {
				moveDirection = -1;
			}
			else if(player.position.x > transform.position.x+0.3) {
				moveDirection = 1;
			}
			else {
				vecVelocity = velocity * Vector3.right;
			}
		}
		else {
			vecVelocity = velocity * Vector3.right;
			if(transform.position.x > rightX) {
				moveDirection = -1;
			}
			if(transform.position.x < leftX) {
				moveDirection = 1;
			}
		}

		transform.position += moveDirection * vecVelocity;

		//转向
		if(moveDirection == 1) {
			transform.localScale = new Vector3(-1, 1, 1);
		}
		else {
			transform.localScale = new Vector3(1, 1, 1);
		}
	}

}
