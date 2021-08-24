using UnityEngine;
using System.Collections;

public class MainProcess : MonoBehaviour {


	//人物相对速度
	public float speed = 6.0F;
	//人物跳起速度
	public float jumpSpeed = 8.0F;
	//重力参数
	public float gravity = 20.0F;
	//人物运动方向
	private Vector3 moveDirection = Vector3.zero;
	//人物角色控制器
	private CharacterController controller;
	//游戏物体
	private GameObject player;
	//用来判断左右移动
	private float x = 0;
	//用来判断前后运动
	private float z = 0;
	void Start()
	{
		//获取Player这个游戏物体
		player = GameObject.Find ("Player");
		//获取人物身上的角色控制器
	 	controller = player.GetComponent<CharacterController>();
	}
	void Update() 
	{
		//当esc被按下退出
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();

		}


		//任务是否在地面
		if (controller.isGrounded) 
		{
			//"Horizontal" 和"Vertical" 映射于控制杆、A、W、S、D和箭头键（方向键）。 
			//这里的意思是检测那个键被按下。Vertical,按下W，z>0,按下S,z<0;不做操作Z= 0；同理，Horizontal也一样
			x = Input.GetAxis("Horizontal");
			z = Input.GetAxis("Vertical");
			if(x == 0 && z == 0)
			{
				//如果没有检查到纵向和横向都没有运动，那么调用默认等待动画
				player.transform.GetComponent<Animation>().CrossFade("idle");
			}
			else
			{
				//如果检查到纵向和横向都有运动，那么调用“walk”行走动画
				player.transform.GetComponent<Animation>().CrossFade("walk");
			}
			//人物运动方向，这是一个方向向量
			moveDirection = new Vector3(x, 0,z );

			//变换一下方向：从自身坐标到世界坐标变换方向。
			moveDirection = player.transform.TransformDirection(moveDirection);
			moveDirection *= speed;

            //点击space键，向上跳
            if (Input.GetButton("Jump"))
            {
                player.transform.GetComponent<Animation>().CrossFade("jump_pose");
                moveDirection.y = jumpSpeed;
            }
			
		}
		else
		{
			//人物不在地面的话，受重力影响下坠。
			moveDirection.y -= gravity * Time.deltaTime;
		}

		//角色朝某个方向运动
		controller.Move(moveDirection * Time.deltaTime);
	}

}
