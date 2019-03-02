using UnityEngine;
using System.Collections;

public class IronMan_Controller : MonoBehaviour
{
	Animator _anim;
	public float MoveSpeed = 2f;
	public float JumpPower = 30f;
	public Transform Shot_Point;
	public GameObject rocket;
	public ParticleSystem[] Smog;
	bool Attck_ing;
	Vector3 Start_Scale;	
	
	void Start ()
	{
		_anim = GetComponent<Animator> ();
		Start_Scale = transform.localScale;
	}
		
	void Update ()
	{ 		
		//if Ironman move to Left or Right.
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)) { 				
			if (Attck_ing == false) {																			//First ,you can check to Ironman isn't Attacking
				_anim.SetBool ("Move", true);																	//Change to MoveState, and Play Move Animation.
				float xx = Input.GetAxisRaw ("Horizontal"); 													//Read InputDirection.				
				if(Input.GetKey (KeyCode.RightArrow)) {															//Change Scale.X as InputDirection.
					transform.localScale = new Vector3 (-Start_Scale.x, Start_Scale.y, Start_Scale.z);
					transform.Translate (Vector3.left * xx * MoveSpeed * Time.deltaTime);
				} 			
				else if(Input.GetKey (KeyCode.LeftArrow)) {
					transform.localScale = new Vector3 (Start_Scale.x, Start_Scale.y, Start_Scale.z);
				//transform.Translate (Vector3.right * xx * MoveSpeed * Time.deltaTime);							//Move to Ironman.
					transform.Translate (Vector3.right * xx * MoveSpeed * Time.deltaTime);							
				}
			}	
		}else{
			_anim.SetBool ("Move", false);              														//if Ironman don't move, Change Idle State.
		}
			
			
		//if Ironman move to Up.
		if (Input.GetKey (KeyCode.UpArrow)) {
			if (Attck_ing == false) {
				_anim.SetBool ("Jump", true);									//1.Change to Jump State, and Play JumpAnimation.

				//this.rigidbody2D.AddForce (new Vector2 (0, JumpPower));			//2. make to fly to Ironman by Force.
				this.GetComponent<Rigidbody2D>().gravityScale = -5;
				Smog [0].emissionRate = Mathf.Lerp (0, 30, Time.time);			//3. increase particle EmitRate.
				Smog [1].emissionRate = Mathf.Lerp (0, 30, Time.time);
			}	
		} else {																//if Ironman move to Up.
			//Add Gravity
			this.GetComponent<Rigidbody2D>().gravityScale = 5;
			_anim.SetBool ("Jump", false);										//Lift JumpState, 
			Smog [0].emissionRate = Mathf.Lerp (30, 0, Time.time);				//decrease particle EmitRate.
			Smog [1].emissionRate = Mathf.Lerp (30, 0, Time.time);
		}
			
		//if Ironman do Shot.
		if (Input.GetKeyDown (KeyCode.Space)) {		
			_anim.SetTrigger ("Shot");											//Play ShotAnimation.
			Attck_ing = true;													//Prevant change state until Finish this Motion.
		}
		
		if (Input.GetKeyDown (KeyCode.C)) {		
			_anim.SetTrigger ("Headbanging");											//Play ShotAnimation.
			//Attck_ing = true;													//Prevant change state until Finish this Motion.
		}
	}
	
	//if shot Animation Played, make a bullet On Animation.
	public void Shot ()
	{
		Attck_ing = false;
		//Rigidbody2D bulletInstance = Instantiate (rocket, Shot_Point.position, Quaternion.Euler (new Vector3 (0, 0, transform.localScale.x < 0 ? 0 : 180))) as Rigidbody2D;
	}
	
	public void Shot_2 ()
	{
		Attck_ing = false;
		//Rigidbody2D bulletInstance = Instantiate (rocket, Shot_Point.position, Quaternion.Euler (new Vector3 (0, 0, transform.localScale.x < 0 ? 0 : 180))) as Rigidbody2D;
	}
}
