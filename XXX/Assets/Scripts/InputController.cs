using UnityEngine;
using System.Collections;

/*
 * 监听所有输入，用以其他类调用
 */
public class InputController : MonoBehaviour {
	
	public static InputController _instance;
	
	private static bool need2Jump;		// 按下了跳跃键 需要处理跳跃
	private static bool need2Attack;	// 按下了攻击键 需要处理攻击
	
	public float screenWidth;			// 屏幕的宽
	public float screenHeight;			// 屏幕的高
	
	// Use this for initialization
	void Start () {
		// 初始化屏幕的宽高
		screenWidth		=	Screen.width;
		screenHeight 	= 	Screen.height; 
		
		//print ("screenWidth: " + screenWidth);
		
		// 实例化单例
		_instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
		// 鼠标左键
//		if(Input.GetKeyDown(KeyCode.Mouse0))
//		{
//			// 鼠标左键点在屏幕上的点
//			Vector3 mousePos	=	Input.mousePosition;
//			print(mousePos);
//			
//			if(mousePos.x <= screenWidth/2) 	// 点在右半屏幕 跳跃控制
//			{
//				need2Jump	=	true;
//			}
//			else 							// 点在左半屏幕 攻击控制
//			{
//				need2Attack	=	true;
//			}
//		}

		if(Input.GetKeyDown(KeyCode.Space)) {
			need2Jump = true;
		}
		if(Input.GetKeyDown(KeyCode.Mouse0)) {
			need2Attack = true;
		}
	}
	
	// 是否输入了跳 如果是返回true并设置回false 如果不是返回false
	public bool GetIfNeedJump()
	{
		if(need2Jump)
		{
			need2Jump = false;
			return true;
		}
		return false;
	}
	
	// 是否输入了攻击 如果是返回true并设置回false 如果不是返回false
	public bool GetIfNeedAttack()
	{
		if(need2Attack)
		{
			need2Attack = false;
			return true;
		}
		return false;
	}
}

