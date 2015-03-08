using UnityEngine;
using System.Collections;

/*
 * Player的控制类
 */
public class PlayerController : MonoBehaviour {

	private InputController inputController;	// 输入控制器
	private PlayerAbility playerAbility;		// 人物的参数控制器
	private LifeCounter lifeCounter;			// 血量控制器

	private Animator anim;			// 状态机
	public bool isOnCround4SM;		// 是否在地面上 状态
	public bool isAttacking4SM;		// 是否攻击 状态
	public bool isSpring4SM;		// 是否踩在弹簧上
	public float velocityY4SM;		// 速度 状态	

	public int hasJumpCnt;			// 连续跳跃的次数

	private int weaponUnableCnt; 	//武器collider隐藏延迟

	//所持的武器
	private GameObject weapon;
	private BoxCollider2D weaponBox;
	// Use this for initialization
	void Start () {
		inputController = InputController._instance;	// 输入控制器的单例
		playerAbility = PlayerAbility._instance;		// 人物的参数控制器
		lifeCounter = LifeCounter._instance;			// 血条控制器
		anim = this.GetComponent<Animator>();			// 状态机

		isOnCround4SM 	= false;	// 初始不在地面上
		isAttacking4SM 	= false;	
		hasJumpCnt = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(inputController == null)
			inputController = InputController._instance;
        if (lifeCounter == null)
            lifeCounter = LifeCounter._instance;
        if (playerAbility == null)
            playerAbility = PlayerAbility._instance;

		// 如果输入了跳跃
		if(inputController.GetIfNeedJump() && hasJumpCnt <= 1)
		{
			//print ("jumping");
			hasJumpCnt ++;	// 多连续跳了一次

			Vector2 tt = rigidbody2D.velocity;
			tt.y = playerAbility.jumpSpeed;
			rigidbody2D.velocity = tt;
		}

		// 如果输入了攻击
		if(inputController.GetIfNeedAttack() && isOnCround4SM)
		{
			//print ("attack");
			isAttacking4SM = true;

		}

		// 保持前进速度
		Vector2 target = new Vector2(playerAbility.runSpeed, rigidbody2D.velocity.y);
		rigidbody2D.velocity = target;

		// 设置状态机状态
		anim.SetBool 	("isOnGround",	isOnCround4SM	);
		anim.SetBool 	("isAttacking",	isAttacking4SM	);
		anim.SetBool 	("isSpring",	isSpring4SM	);
		velocityY4SM = rigidbody2D.velocity.y;
		anim.SetFloat 	("velocityY",	velocityY4SM	);

		//武器collider设置 
		weaponController();
	}

	// 在动画中调用 播完攻击动画后设为false
	public void ResetAttack()
	{
		isAttacking4SM = false;
	}

	// 开始碰撞
	public void OnCollisionEnter2D(Collision2D col)
	{
		// 从上边碰到地面
		if(col.gameObject.tag == "Ground" && 
		   Mathf.Abs(col.contacts[0].point.y - col.contacts[1].point.y) < 0.01f &&
		   transform.position.y > col.contacts[0].point.y) // 横着碰到不会触发效果
		{
			isOnCround4SM = true;
			hasJumpCnt = 0;
		}
		else if(col.gameObject.tag == "Spring" && 
		        Mathf.Abs(col.contacts[0].point.y - col.contacts[1].point.y) < 0.01f) // 横着碰到不会触发效果
		{
			isSpring4SM = true;
			StartCoroutine("SpringJump");
		}
	}

	// 离开碰撞
	public void OnCollisionExit2D(Collision2D col)
	{
		if(col.gameObject.tag == "Ground" &&
		   Mathf.Abs(col.contacts[0].point.y - col.contacts[1].point.y) < 0.01f &&
		   transform.position.y > col.contacts[0].point.y) // 从上边碰到才会触发
		{
			isOnCround4SM = false;
		}
		else if(col.gameObject.tag == "Spring")
		{
			isSpring4SM = false;
		}
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "SlowDown")
		{
			playerAbility.SlowDown();
		}
		else if(col.tag == "SpeedUp")
		{
			playerAbility.SpeedUp();
		}
		else if(col.tag == "JumpHigher")
		{
			playerAbility.JumpHigher();
		}
		else if(col.tag == "Ghost") 
		{

			lifeCounter.GetAttack();
			Debug.Log("Ghost! need to diaoxue"+ Time.time.ToString());
		}
	}

	public float springCOE = 1.5f;	// 弹跳的倍数 
	
	// 就是弹跳力乘2 动画里调用
	IEnumerator SpringJump()
	{
		yield return new WaitForSeconds (0.1f);
		Vector2 tt = rigidbody2D.velocity;
		tt.y = playerAbility.jumpSpeed*springCOE;
		rigidbody2D.velocity = tt;
	}
	public void weaponController() {
		//获得武器gameobject 和 boxCollider2d 
		if(weapon == null) {
			weapon = GameObject.FindGameObjectWithTag("Weapon");
			weaponBox = weapon.GetComponent<BoxCollider2D>();
			return ;
		}
		weapon.transform.position = transform.position + new Vector3(2,0,0);
		if(isAttacking4SM == true) {
			weaponBox.enabled = true;
			weaponUnableCnt = 0;
		}
		else {
			//有延迟隐藏武器碰撞盒
			weaponUnableCnt ++;
			if(weaponUnableCnt == 30) {

				weaponBox.enabled = false;
				Debug.Log("weapon unabled");
				weaponUnableCnt = 0;
			}
		}
	}

}
