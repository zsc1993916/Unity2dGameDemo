using UnityEngine;
using System.Collections;

/*
 * 控制GameObject跟随Player移动，可以设顶XY的相对阻尼
 */
public class SmartFollow : MonoBehaviour {

	public float achieveTime = 3; 	// 用于Lerp 秒数
	public float upDownSize;
	public float leftRightSize;
	private float orginX, orginY, orginZ;
	
	
	private Transform playerTransform;		// 跟随焦点的Transfrom
	
	
	// Use this for initialization
	void Start () {
		
		// 拿到需要的 transform
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		orginX = transform.position.x;
		orginY = transform.position.y;
		orginZ = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 targetPos = playerTransform.position + 
			new Vector3 (orginX - playerTransform.position.x * leftRightSize, 
			             orginY - playerTransform.position.y * upDownSize, orginZ);
		
		transform.position = Vector3.Lerp (transform.position, targetPos, achieveTime);
	}
}
