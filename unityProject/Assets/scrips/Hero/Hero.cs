using UnityEngine;
using System.Collections;

public class Hero : ITangible, ICoreInput
{
		private readonly float RUNSPEED = 0.05f;

		private readonly float ROLLSPEED = 0.04f;

		private readonly float JUMPSPEED = 7.5f;

		public bool goJump;

		public bool grounded;
			
		private bool run;

		public bool inLadder; 

		private Animator animator;

		private string name;

		private float maxHeight;

		public bool topLadderGround;
		
		public bool baseLadderGround;
		
		private Transform groundCheck;


		public Hero () : base(50,10)
		{
			
		}

		// Use this for initialization
		public override void Start ()
		{		
				groundCheck = transform.Find ("GroundCheck");

				this.animator = this.GetComponentInChildren<Animator> ();

				this.facingRight = true;

				this.goJump = false;	
			
				this.grounded = true;
		
				this.run = false;

				this.inLadder = false;

				this.maxHeight = 8f;

		}
	
		// Update is called once per frame
		public override void Update ()
		{
		
				grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));

				if (grounded) {
						goJump = false;
				}
			
				this.registerInputs ();

				this.roll ();
				
				if ((!inLadder) && (goJump) && (grounded)) {								
						this.jump ();
				}
				
				if ((!inLadder) || (topLadderGround) || (baseLadderGround) || (goJump)) {
						transform.rigidbody2D.gravityScale = 1;
						this.move ();
				} else {
						this.animator.SetBool (AnimatorParameterEnum.RUN.name, false);
				}

				if (this.weapon != null) {
						this.weapon.Update ();
				}
				
				grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));

				if (inLadder && !goJump) {
						transform.rigidbody2D.gravityScale = 0;
						transform.rigidbody2D.velocity = Vector2.zero;
						this.climb ();
				}
		}

		private void roll ()
		{
				int mult = 0;
				if (AnimationUtils.animatorStateEquals (this.animator, AnimationEnum.HERO_ROLLING)) {
						if (this.facingRight) {
								mult = 1;
						} else {
								mult = -1;
						}
						
						this.transform.position += new Vector3 (ROLLSPEED * mult, 0, 0) * Time.deltaTime;
						this.transform.collider2D.isTrigger = true;
				} else {
						this.transform.collider2D.isTrigger = false;
				}
		}

		private void jump ()
		{		
				grounded = false;
				AnimationUtils.animatorStateEquals (this.animator, AnimationEnum.HERO_JUMPING);						
				this.rigidbody2D.velocity = new Vector2 (0, 1) * JUMPSPEED;
				
				
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

				this.transform.position += new Vector3 (RUNSPEED * mult, 0, 0);			 				

				this.animator.SetBool (AnimatorParameterEnum.RUN.name, run);
		}

		private void climb ()
		{	
				int mult = 0;	
				
				if (!baseLadderGround) {
						if (Input.GetKey (KeyCode.DownArrow)) {
								mult = -1;
						} 
				}		
				if (!topLadderGround) {
						if (Input.GetKey (KeyCode.UpArrow)) {
								mult = 1;
						}
				}
				this.transform.position += new Vector3 (0, RUNSPEED * mult, 0);
		}		

		//Override
		public void registerInputs ()
		{
				//Roll
				if (Input.GetButtonDown (InputEnum.ROLL.name) && AnimationUtils.animatorStateEquals (this.animator, AnimationEnum.HERO_RUNNING)) {
						animator.SetTrigger (AnimatorParameterEnum.ROLL.name);
				}

				//Jump
				if (Input.GetButtonDown (InputEnum.JUMP.name) && grounded == true) {
						goJump = true;
						this.animator.SetTrigger (AnimatorParameterEnum.JUMP.name);
				}

				//Attack
				if (Input.GetButtonDown (InputEnum.ATTACK.name)) {
						this.animator.SetTrigger (AnimatorParameterEnum.ATTACK.name);
				}
		}

		public override void hit (int damage)
		{
				if (!AnimationUtils.animatorStateEquals (this.animator, AnimationEnum.HERO_ROLLING)) {
						base.hit (damage);
						
				}
		}
}