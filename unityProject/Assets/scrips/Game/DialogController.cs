//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.33440
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;
using System.Collections;

public class DialogController : MonoBehaviour
{

		private static SpriteRenderer sprite;

		private static GUIText text;


		public void Start ()
		{
				sprite = this.GetComponent<SpriteRenderer> ();
				text = this.GetComponentInChildren<GUIText> ();
				sprite.enabled = false;
				text.text = "";
		}

		public static IEnumerator Speak (String sayThis)
		{
				setVisible (true);

				float alpha = 0;

				while (alpha < 1) {
						alpha += 0.1f;
						yield return new WaitForSeconds (0.1f);
						text.color = new Color (text.color.r, text.color.g, text.color.b, alpha);
						sprite.color = new Color (sprite.color.r, sprite.color.g, sprite.color.b, alpha);
				}
//				text.text = sayThis;
		}

		public static void setVisible (bool visibility)
		{
				text.enabled = visibility;
				sprite.enabled = visibility;
		}

		public void setTextPosition (Vector3 vector)
		{
				text.transform.position = vector + new Vector3 (text.pixelOffset.x, text.pixelOffset.y, 0);
		}

}
