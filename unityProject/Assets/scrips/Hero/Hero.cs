﻿using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour
{

		private float maxSpeed;

		private float roolSpeed;

		private bool facingRight;

		private Animator animator;

		private bool rolling;

		// Use this for initialization
		void Start ()
		{

				this.animator = GetComponent<Animator> ();

				this.maxSpeed = 5f;

				this.roolSpeed = 10f;

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
				if (Input.GetButtonDown ("Jump") && AnimationUtils.animatorStateEquals (this.animator, AnimationEnum.RUNNING)) {
						this.animator.SetTrigger ("rolling");
				}

		}

		private void move ()
		{
				//Running State Control
				float movement = Input.GetAxis ("Horizontal");
				this.animator.SetFloat ("speed", Mathf.Abs (movement));
				this.rigidbody2D.velocity = new Vector2 (movement * this.maxSpeed, this.rigidbody2D.velocity.y);
				if (movement > 0 && !this.facingRight) {
						this.flip ();
				} else if (movement < 0 && this.facingRight) {
						this.flip ();
				}
		}

		private void flip ()
		{
				this.facingRight = !this.facingRight;
				Vector3 scale = transform.localScale;
				scale.x *= -1;
				this.transform.localScale = scale;
		}
}
