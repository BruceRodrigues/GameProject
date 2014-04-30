using UnityEngine;
using System.Collections;

public class Hero : ITangible, ICoreInput
{
	private readonly float RUNSPEED = 0.05f;

	private readonly float ROLLSPEED = 0.04f;

	private readonly float JUMPSPEED = 5f;

	private bool facingRight;

	private bool grounded;
			
	private bool run;

	private bool inLadder; 

	private Animator animator;

	public Hero () : base(50,10)
	{
			
	}

	// Use this for initialization
	public override void Start ()
	{
		this.animator = transform.GetComponent<Animator> ();
		SpriteRenderer sr = transform.GetComponent<SpriteRenderer> ();
		sr.enabled = true;

		this.facingRight = true;

		this.grounded = false;
		
		this.run = false;

		this.inLadder = false;

	}
	
	// Update is called once per frame
	public override void Update ()
	{
		this.registerInputs ();

		this.roll ();

		this.jump ();

		this.move ();

		if (this.weapon != null) {
			this.weapon.Update ();
		}

//				this.climb ();

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

			this.rigidbody2D.transform.position += new Vector3 (ROLLSPEED * mult, 0, 0);
		}
	}

	private void jump ()
	{
		if (AnimationUtils.animatorStateEquals (this.animator, AnimationEnum.HERO_JUMPING)) {
			this.rigidbody2D.velocity = new Vector2 (0, this.JUMPSPEED);
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

		this.animator.SetBool (AnimatorParameterEnum.RUN.name, run);
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
		if (this.inLadder) {
				
			if (Input.GetKey (KeyCode.DownArrow)) {
				if (!grounded)
					mult = -1;
			} else if (Input.GetKey (KeyCode.UpArrow)) {
				mult = 1;
			}

			this.rigidbody2D.transform.position += new Vector3 (0, RUNSPEED * mult, 0);
		}
	}

	void OnTriggerEnter2D (Collider2D coll)
	{

		Debug.Log ("TRIGGER");
		this.rigidbody2D.velocity = Vector2.zero;
		if (coll.gameObject.tag == TagEnum.LADDER.name) {
			inLadder = true;
		}

		if (coll.gameObject.tag == TagEnum.GROUND.name) {
			grounded = true;
		}
	}

	void OnTriggerExit2D (Collider2D coll)
	{
		if (coll.gameObject.tag == TagEnum.LADDER.name) {
			inLadder = false;
		}

		if (coll.gameObject.tag == TagEnum.GROUND.name) {
			grounded = false;
		}
	}

	//Override
	public void registerInputs ()
	{
		//Roll
		if (Input.GetButtonDown (InputEnum.ROLL.name) && AnimationUtils.animatorStateEquals (this.animator, AnimationEnum.HERO_RUNNING)) {
			animator.SetTrigger (AnimatorParameterEnum.ROLL.name);
		}

		//Jump
		if (Input.GetButtonDown (InputEnum.JUMP.name)) {
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