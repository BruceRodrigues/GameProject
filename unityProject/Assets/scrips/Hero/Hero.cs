using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour
{

		private readonly float RUNSPEED = 0.05f;

		private readonly float ROLLSPEED = 0.04f;

		private bool facingRight;

		private Animator animator;

		// Use this for initialization
		void Start ()
		{

				this.animator = GetComponent<Animator> ();

				this.facingRight = true;
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				this.roll ();
				this.move ();
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
				if (Input.GetKey (KeyCode.RightArrow)) {
						this.animator.SetBool ("run", true);
						if (this.facingRight) {
								mult = 1;
						} else {
								this.flip ();
						}
				} else if (Input.GetKey (KeyCode.LeftArrow)) {
						this.animator.SetBool ("run", true);
						if (!this.facingRight) {
								mult = -1;
						} else {
								this.flip ();
						}
				}
				if (Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.LeftArrow)) {
						this.animator.SetBool ("run", false);
				}
				this.rigidbody2D.transform.position += new Vector3 (RUNSPEED * mult, 0, 0);
		}

		private void flip ()
		{
				this.facingRight = !this.facingRight;
				Vector3 scale = transform.localScale;
				scale.x *= -1;
				this.transform.localScale = scale;
		}
}
