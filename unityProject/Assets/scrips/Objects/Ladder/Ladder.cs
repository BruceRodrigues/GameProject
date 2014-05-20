using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour
{

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
				if (coll.gameObject.layer == LayerEnum.TANGIBLE.number) {
						Hero hero = Collider2D.FindObjectOfType<Hero> ();
						hero.inLadder = true;			
						Debug.Log ("OnLadder");	
				}
		}
		void OnTriggerExit2D (Collider2D coll)
		{
				if (coll.gameObject.layer == LayerEnum.TANGIBLE.number) {
						Hero hero = Collider2D.FindObjectOfType<Hero> ();
						hero.inLadder = false;
						Debug.Log ("OutLadder");
			
				}
		
		}
}
