using UnityEngine;
using System.Collections;

public class LadderGround : MonoBehaviour
{
		public GameObject ladderGround;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnTriggerEnter2D (Collider2D coll)
		{
				if (coll.gameObject.layer == LayerEnum.GrondCheck.number) {
						Hero hero = Collider2D.FindObjectOfType<Hero> ();
						
						if (ladderGround.layer == LayerEnum.TLadderGround.number) {
								hero.topLadderGround = true;
						}

						if (ladderGround.layer == LayerEnum.BLadderGround.number) {
								hero.baseLadderGround = true;
						}
						

						
						Debug.Log ("OnLadderGround");	
				}
		}

		void OnTriggerExit2D (Collider2D coll)
		{
				if (coll.gameObject.layer == LayerEnum.GrondCheck.number) {
						Hero hero = Collider2D.FindObjectOfType<Hero> ();
			
						if (ladderGround.layer == LayerEnum.TLadderGround.number) {
								hero.topLadderGround = false;
						}
			
						if (ladderGround.layer == LayerEnum.BLadderGround.number) {
								hero.baseLadderGround = false;
						}
						
						Debug.Log ("OutLadderGround");	
				}
		
		}
}