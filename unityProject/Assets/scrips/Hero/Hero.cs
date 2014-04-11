using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour
{

		public Transform hero;

		private readonly float RUNSPEED = 0.05f;

		private readonly float ROLLSPEED = 0.04f;

		private bool facingRight;

		private bool grounded;
			
		private bool run;

		private bool inLadder; 

		private Animator animator;

		// Use this for initialization
		void Start ()
		{
				this.animator = hero.GetComponent<Animator> ();

				this.facingRight = true;

				this.grounded = false;
		
				this.run = false;

				this.inLadder = false;
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (grounded && !inLadder) {
						this.roll ();
				}
				this.move ();

				if (inLadder)
						this.climb ();

				if (!grounded && !inLadder) {
						this.rigidbody2D.gravityScale = 1;
				}

		}

		private void roll ()
		{
				int mult = 0;
				if (Input.GetButtonDown ("Jump") && AnimationUtils.animatorStateEquals (this.animator, AnimationEnum.RUNNING)) {
						this.animator.SetTrigger ("roll");
				}
				if (AnimationUtils.animatorStateEquals (this.animator, AnimationEnum.ROLLING)) {
						if (this.facingRight) {
								mult = 1;
						} else {
								mult = -1;
						}
						this.rigidbody2D.transform.position += new Vector3 (ROLLSPEED * mult, 0, 0);
				}

		}

		private void move ()
		{		
				//Running State Control
				int mult = 0;
				run = false;

				if (Input.GetKey (KeyCode.RightArrow)) {
						run = true;
						if (this.facingRight) {
								mult = 1;
						} else {
								this.flip ();
						}
				} else if (Input.GetKey (KeyCode.LeftArrow)) {
						run = true;
						if (!this.facingRight) {
								mult = -1;
						} else {
								this.flip ();
						}
				}
					
				if (Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.LeftArrow)) {
						run = false;
				}
				
				this.rigidbody2D.transform.position += new Vector3 (RUNSPEED * mult, 0, 0);			 				

				this.animator.SetBool ("run", run);
		}

		private void flip ()
		{
				this.facingRight = !this.facingRight;
				Vector3 scale = transform.localScale;
				scale.x *= -1;
				this.transform.localScale = scale;
		}

		private void climb ()
		{	
				int mult = 0;
				
				if (Input.GetKey (KeyCode.DownArrow)) {
						if (!grounded)
								mult = -1;
				} else if (Input.GetKey (KeyCode.UpArrow)) {
						mult = 1;
				}

				this.rigidbody2D.transform.position += new Vector3 (0, RUNSPEED * mult, 0);


		}

		void OnTriggerEnter2D (Collider2D coll)
		{
				this.rigidbody2D.gravityScale = 0;
				this.rigidbody2D.velocity = Vector2.zero;
				if (coll.gameObject.tag == "ladder") {
						inLadder = true;
				}

				if (coll.gameObject.tag == "ground") {
						grounded = true;
				}
		}

		void OnTriggerExit2D (Collider2D coll)
		{
				if (coll.gameObject.tag == "ladder") {
						inLadder = false;
				}

				if (coll.gameObject.tag == "ground") {
						grounded = false;
				}
		}
		
		
		
		
}
