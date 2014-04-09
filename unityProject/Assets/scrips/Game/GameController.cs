using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

		void Awake ()
		{
				Application.targetFrameRate = 60;
				Debug.Log ("AWAKE");
		}
}
