using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {

	public Transform mesh;
	public float jumpForce;
	public float moveForce;
	public float maxSpeed;

	private bool facingRight;
	private bool andar;
	private bool jump;
	private bool grounded;
	private Animator animationRun;
	private Transform groundCheck;

	// Use this for initialization
	void Start () {
		animationRun = mesh.GetComponent<Animator>();
		groundCheck = transform.Find("GroundCheck");
		facingRight = true;
		andar = false;
		jump = false;
		grounded = true;
	}
	

	void Update () {
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  // verifica se o Hero esta no chao

		if (grounded)
		{

			float h = Input.GetAxis ("Horizontal");  //verifica para qual lado o jogador apertou a tecla -1 ... 1 e pega o valor da intensidade

			if(h * rigidbody2D.velocity.x < maxSpeed) //verifica se ainda nao atigiu a velociadade maxima para o lado que esta virado
				// adiciona a forca ao Hero.
				rigidbody2D.AddForce(Vector2.right * h * moveForce);

			if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed) //verifica se agora atingiu a velocidade maxima
				rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y); // nivela o player na velocidade maxima

			//verifica se o jogador apertou os botoes de esquerda ou direita para qual lado o Hero estava.
			if (h > 0 && !facingRight) {
							// ... vira o personagem.
							Flip ();
					} else if (h < 0 && facingRight) {
							// ... vira o personagem.						
							Flip ();
					}

			h = Input.GetAxis ("Horizontal");  //verifica mais uma vez se o jogador esta apertando para andar
			
			if (Mathf.Abs (h) != 1) {
							rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y);
							andar = false;
					} else {
						andar = true;
					}

			//verifica se o jogador apertou a tecla para pula e se o hero esta no chao
			if (Input.GetButtonDown ("Jump") && grounded) {
				Jump ();
					}

			animationRun.SetBool ("Run", andar);
		}
	
	}

	void Flip()
	{
		facingRight = !facingRight;
		rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y);
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void Jump()
	{
		rigidbody2D.AddForce(new Vector2(0f, jumpForce));
		andar = false;
	}


}
