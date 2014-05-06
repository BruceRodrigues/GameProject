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
using System.Collections.Generic;

public class DialogBox : MonoBehaviour, ICoreInput
{

		private List<String> dialogs;

		public SpriteRenderer SpriteRenderer;

		private Animator animatorDialog;

		public DialogBox ()
		{
		}

		public void Start ()
		{
				this.animatorDialog = this.GetComponent<Animator> ();
				this.SpriteRenderer.enabled = false;
		}

		public void Update ()
		{
				this.registerInputs ();

				if (AnimationUtils.animatorStateEquals (this.animatorDialog, AnimationEnum.DIALOGBOX_HIDDEN)) {
						this.SpriteRenderer.enabled = false;
						DialogController.setVisible (false);
				} else if (AnimationUtils.animatorStateEquals (this.animatorDialog, AnimationEnum.DIALOGBOX_FADEIN)) {
						this.SpriteRenderer.enabled = true;
				}
		}

		public DialogBox (List<String> dialogs)
		{
				this.dialogs = dialogs;
		}

		public void setDialog (List<String> dialogs)
		{
				this.dialogs = dialogs;
		}

		public String getDialog (int index)
		{
				return this.dialogs [index];
		}

		public void enable ()
		{
				if (AnimationUtils.animatorStateEquals (this.animatorDialog, AnimationEnum.DIALOGBOX_HIDDEN)) {
						this.animatorDialog.SetBool (AnimatorParameterEnum.DIALOGBOX_HEROIN.name, true);
				}
		}

		public void disable ()
		{
				if (AnimationUtils.animatorStateEquals (this.animatorDialog, AnimationEnum.DIALOGBOX_VISIBLE) || AnimationUtils.animatorStateEquals (this.animatorDialog, AnimationEnum.DIALOGBOX_FADEIN)) {
						this.animatorDialog.SetBool (AnimatorParameterEnum.DIALOGBOX_HEROIN.name, false);
				}
		}

		//Override
		public void registerInputs ()
		{
				if (Input.GetButtonDown (InputEnum.ATTACK.name)) {
						if (AnimationUtils.animatorStateEquals (this.animatorDialog, AnimationEnum.DIALOGBOX_VISIBLE) || 
								AnimationUtils.animatorStateEquals (this.animatorDialog, AnimationEnum.DIALOGBOX_FADEIN)) {
								StartCoroutine (DialogController.Speak (dialogs [0]));
						}

				}
		}

}
