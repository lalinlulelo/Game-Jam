using UnityEngine;
using System.Collections;

public class CommanderKeen : MonoBehaviour
{
	public float walkSpeed;
    public Animator animator;
    Vector3 prevMoveDirection;
	
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 moveDirection = Vector3.zero;

		if (Input.GetKey (KeyCode.LeftArrow))
			moveDirection.x = -1f;
		if (Input.GetKey (KeyCode.RightArrow))
			moveDirection.x = 1f;
		if (Input.GetKey (KeyCode.UpArrow))
			moveDirection.y = 1f;
		if (Input.GetKey (KeyCode.DownArrow))
			moveDirection.y = -1f;

		transform.position += moveDirection * walkSpeed * Time.deltaTime;

        if (moveDirection.sqrMagnitude > 0)
        {
            animator.SetBool("walk", true);
            prevMoveDirection = moveDirection;
        }
        else
        {
            animator.SetBool("walk", false);
            moveDirection = prevMoveDirection;
        }

        animator.SetFloat("MoveX", moveDirection.x);
        animator.SetFloat("MoveY", moveDirection.y);
	}

}
