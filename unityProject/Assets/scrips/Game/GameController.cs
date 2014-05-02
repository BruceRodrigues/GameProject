using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
		public GameObject cam;
		public GameObject hero;
		private Camera camera;
		public DialogController dialogController;

		void Awake ()
		{
				Application.targetFrameRate = 60;

		}

		public void Start ()
		{

				this.camera = this.cam.GetComponent<Camera> ();
		}

		void Update ()
		{
				cam.transform.position = new Vector3 (hero.transform.position.x, hero.transform.position.y, -10);

				dialogController.transform.position = new Vector3 (cam.transform.position.x - 1, this.cam.transform.position.y - 1, -1);
				this.dialogController.setTextPosition (this.camera.WorldToViewportPoint (this.cam.transform.position));
		}

}
