using UnityEngine;
using System.Collections;

public class LadderGround : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void OnTriggerEnter2D (Collider2D coll)
		{
				if (coll.gameObject.layer == LayerEnum.TANGIBLE.number) {
						//	ITangible tangible = Collider2D.FindObjectOfType<ITangible> ();
						//tangible.hit (this.damage);
				}
		}
}
