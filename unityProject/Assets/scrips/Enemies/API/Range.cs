using UnityEngine;
using System.Collections;

public class Range : MonoBehaviour
{

		private int width { get; set; }
		private int height { get; set; }

		private bool reach;

		// Use this for initialization
		void Start ()
		{
				this.reach = false;
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void OnTriggerEnter2D (Collider2D coll)
		{
				Debug.Log ("REACH");
				this.reach = true;
		}

		public void OnTriggerExit2D (Collider2D coll)
		{
				this.reach = false;
		}

		public bool canReach ()
		{
				return this.reach;
		}
}
