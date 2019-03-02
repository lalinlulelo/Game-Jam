using UnityEngine;
using System.Collections;

public class RockMan_Controller : MonoBehaviour
{
	Animator _anim;
	public float MoveSpeed = 5f;
	public float JumpPower = 400f;
	private Rigidbody2D m_Rigidbody2D;
	//public Transform Shot_Point;
	//public GameObject rocket;
	//public ParticleSystem[] Smog;
	//bool Attck_ing;
	Vector3 Start_Scale;	

	void Start ()
	{
		_anim = GetComponent<Animator> ();
		Start_Scale = transform.localScale;
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	void Update ()
	{ 		
		//if RockMan move to Left or Right.
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)) { 				
																			//First ,you can check to Ironman isn't Attacking
				_anim.SetBool ("Move", true);																	//Change to MoveState, and Play Move Animation.
				float xx = Input.GetAxisRaw ("Horizontal"); 													//Read InputDirection.				
				if(Input.GetKey (KeyCode.RightArrow)) {															//Change Scale.X as InputDirection.
					transform.localScale = new Vector3 (Start_Scale.x, Start_Scale.y, Start_Scale.z);
					transform.Translate (Vector3.right * xx * MoveSpeed * Time.deltaTime);
				} 			
				else if(Input.GetKey (KeyCode.LeftArrow)) {
					transform.localScale = new Vector3 (-Start_Scale.x, Start_Scale.y, Start_Scale.z);
					//transform.Translate (Vector3.right * xx * MoveSpeed * Time.deltaTime);							//Move to Ironman.
					transform.Translate (Vector3.left * xx * MoveSpeed * Time.deltaTime);							
				}
				
		}else{
			_anim.SetBool ("Move", false);              														//if Ironman don't move, Change Idle State.
		}

		//if Ironman do Jump.
		if (Input.GetKeyDown (KeyCode.Space)) {		
			m_Rigidbody2D.AddForce(new Vector2(0f, JumpPower));
			//_anim.SetTrigger ("Jump");											//Play ShotAnimation.													//Prevant change state until Finish this Motion.
		}
		//if Ironman do Shoot.
		if (Input.GetButtonDown("Fire1")){	
			//m_Rigidbody2D.AddForce(new Vector2(0f, JumpPower));
			_anim.SetTrigger ("Shoot");											//Play ShotAnimation.													//Prevant change state until Finish this Motion.
		}
	}
}
