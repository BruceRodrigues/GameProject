using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
		public GameObject cam;
		public GameObject hero;

		void Awake ()
		{
				Application.targetFrameRate = 60;
				
		}

		void Update ()
		{
				cam.transform.position = new Vector3 (hero.transform.position.x, hero.transform.position.y, -10);
		}

}
