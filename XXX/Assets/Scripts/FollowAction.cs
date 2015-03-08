using UnityEngine;
using System.Collections;

/*
 * 在一定范围内 跟随player，超出范围回到原位
 */
public class FollowAction : MonoBehaviour {
	
	//搜寻半径
	public float size = 10f;
	//跟随速度
	public float velocity = 0.07f;
	//是否转向
	public bool bIsLookAt = true;

	//搜寻目标
	private Transform targetPlayer;
	//道具本来的位置
	private Vector3 originPoistion;
	//朝向目标
	private Vector3 target;
	// Use this for initialization
	void Start () {
		originPoistion = this.transform.position;
		targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		//判断目标是 人物还是道具本来的位置
		if(Vector3.Distance(this.transform.position, targetPlayer.position) < size) {
			target = targetPlayer.position;
		}
		else {
			target = originPoistion;
		}

		//向目标移动
		this.transform.position = Vector3.MoveTowards(this.transform.position, target, velocity);

		//转向
		if(bIsLookAt) {
			if(this.transform.position.x < target.x) {
				this.transform.localScale =  new Vector3(-1, 1, 1);
			}
			else {
				this.transform.localScale = new Vector3(1, 1, 1);
			}
		}
	}
}
