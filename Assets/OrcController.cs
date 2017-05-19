using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class OrcController : MonoBehaviour {

	public Animator anim;

	public Transform player;

	private float inputH;
	private float inputV;
	public float rotateSpeed = 0.1F;

	public float speed = 60.0F * Random.Range(1.0f, 10.0f);
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;

	void Start(){
		anim = GetComponent<Animator> ();

//		float moveX = Random.Range (-1.0f, 1.0f)*20f*Time.deltaTime;
//		float moveZ = Random.Range (-1.0f, 1.0f)*50f*Time.deltaTime;

//		Vector3 velocity = new Vector3(moveX*20f, 0f, moveZ*50f);
//		rbody.AddForce (velocity);
	}

	void Update(){

		if (Input.GetKey ("i")) {
			if (Input.GetKey ("o")) {
				anim.Play ("HumanoidRun", -1, 0f);
			} else {
				anim.Play ("HumanoidWalk", -1, 0f);
			}
		}
		if (Input.GetKey("m")){
			anim.Play ("HumanoidJumpUp", -1, 0f);
		}

		inputH = Input.GetAxis("Horizontal");
		inputV = Input.GetAxis ("Vertical");


//		if (moveX < 0) {
//			moveX = moveX * -1;
//		}
//		if (moveZ < 0) {
//			moveZ = moveZ * -1;
//		}

		anim.SetFloat ("Forward", inputV);
		anim.SetFloat ("Turn", inputH);

		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector3(inputH, 0, inputV);

			//		Vector3 NextDir = new Vector3(inputH * rotateSpeed, 0, inputV * rotateSpeed);
			//		Vector3 NextDir = new Vector3(moveDirection.x * rotateSpeed, 0, moveDirection.z * rotateSpeed);
			//		Vector3 NextDir = Vector3.Lerp(transform.position, transform.position + moveDirection.normalized, Time.fixedDeltaTime * rotateSpeed);
			Vector3 NextDir = transform.TransformDirection (moveDirection.x * rotateSpeed, 0, moveDirection.z * rotateSpeed);
			print (NextDir);
			//		Vector3 NextDir = moveDirection;
			//		Vector3 NextDir = new Vector3(moveDirection.x * rotateSpeed, 0, moveDirection.x * rotateSpeed);
			if (NextDir != Vector3.zero)
				//			transform.rotation = 
				transform.rotation = Quaternion.LookRotation(NextDir);

			if (moveDirection.magnitude > 1f) moveDirection.Normalize();
//			moveDirection = transform.InverseTransformDirection (moveDirection);
			moveDirection = transform.TransformDirection(moveDirection);
//			moveDirection = Vector3.ProjectOnPlane (moveDirection, Vector3.up);

//			print ("moveDirection.x: ");
//			print (moveDirection.x);
//			print ("moveDirection.z: ");
//			print (moveDirection.z);
//			if (moveDirection.z < 0) {
//				inputV = moveDirection.z * -1;
//			}

//			anim.SetFloat ("Forward", inputV);
//			anim.SetFloat ("Turn", moveDirection.x);
//			anim.SetFloat ("Turn", Mathf.Atan2(moveDirection.x, moveDirection.z));
//			anim.SetFloat ("Turn", inputH);
//			inputH 
//			moveDirection *= speed * Random.Range(0.1f, 3.0f);


			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;

		}
		moveDirection.y -= gravity * Time.deltaTime;
//		if (moveDirection.magnitude > 1f) moveDirection.Normalize();
		moveDirection = transform.InverseTransformDirection(moveDirection);
//		moveDirection = transform.InverseTransformDirection (moveDirection);
//		moveDirection = Vector3.ProjectOnPlane (moveDirection, Vector3.up);
//		move = transform.InverseTransformDirection(move);
		controller.Move(moveDirection * Time.deltaTime);
		controller.detectCollisions = true;

//		print ("moveDirection.x: ");
//		print (moveDirection.x);
//		print ("moveDirection.z: ");
//		print (moveDirection.z);
		if (moveDirection.z < 0) {
//			inputV = moveDirection.z * -1;
		}





//		float tiltAroundZ = inputH * rotateSpeed;
//		float tiltAroundX = inputV * rotateSpeed;
//
//		Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
//		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * rotateSpeed);

//		CharacterController controller = GetComponent<CharacterController>();
//		Vector3 horizontalVelocity = controller.velocity;
//		horizontalVelocity = new Vector3(moveX, 0, moveZ);
////		print (horizontalVelocity);
////		horizontalVelocity = new Vector3(controller.velocity.x, 0, controller.velocity.z);
//		float horizontalSpeed = horizontalVelocity.magnitude;
//		float verticalSpeed = controller.velocity.y;
//		float overallSpeed = controller.velocity.magnitude;

//		CharacterController controller = GetComponent<CharacterController>();
//		transform.Rotate(0, moveX * rotateSpeed, 0);
//		Vector3 forward = transform.TransformDirection(Vector3.forward);
//		float curSpeed = speed * moveZ;
//		controller.SimpleMove(forward * curSpeed);
	}

	void FixedUpdate(){
	}

	void Destroy (){
		Destroy (gameObject);
		Application.LoadLevel(Application.loadedLevel);
	}
	/*
	void ApplyExtraTurnRotation()
	{
		// help the character turn faster (this is in addition to root rotation in the animation)
		float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
		transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
	}
	*/

	void OnCollisionEnter(Collision collisionInfo)
	{
//		print("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
//		print("There are " + collisionInfo.contacts.Length + " point(s) of contacts");
//		print("Their relative velocity is " + collisionInfo.relativeVelocity);

		anim.Play ("HumanoidJumpUp", -1, 0f);

//		Thread.Sleep (5000);
//		if (anim.GetCurrentAnimatorStateInfo (0).normalizedTime > 1)
//			print ("MOrre desgraça");
//		else
//			Destroy (gameObject);
//		while (anim.GetCurrentAnimatorStateInfo (0).normalizedTime < 1) {
//			print ("Morre desgraça");
//		}
//		if (anim.GetCurrentAnimatorStateInfo (0).normalizedTime > 1) {
//			Destroy (gameObject);
//		}

	}
		
}
