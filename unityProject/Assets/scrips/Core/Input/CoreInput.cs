using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoreInput
{

		public enum TypePressed
		{
				PRESSED,
				DOWN,
				UP
		}

		public abstract class Action
		{

				private InputEnum key;
				private TypePressed type;

				public Action (InputEnum key, TypePressed type)
				{
						this.key = key;
						this.type = type;
				}

				public TypePressed getType ()
				{
						return this.type;
				}	

				public string getButton ()
				{
						return this.key.name;
				}

				public abstract void onAction ();
		}


		private List<Action> actions;

		private static CoreInput singleton;

		private CoreInput ()
		{
				this.actions = new List<Action> ();
		}

		public static CoreInput getInstance ()
		{
				if (singleton == null) {
						singleton = new CoreInput ();
				}
				return singleton;
		}

		public void addAction (Action action)
		{
				this.actions.Add (action);
		}

		public void update ()
		{
				bool go = false;
				foreach (Action action in this.actions) {
						go = false;
						switch (action.getType ()) {
						case TypePressed.PRESSED:
								{
										if (Input.GetButton (action.getButton ())) {
												go = true;
										}
										break;
								}
						case TypePressed.DOWN:
								{
										if (Input.GetButtonDown (action.getButton ())) {
												go = true;
										}
										break;
								}
						case TypePressed.UP:
								{
										if (Input.GetButtonUp (action.getButton ())) {
												go = true;
										}
										break;
								}
						default:
								{
										break;
								}
						}
						if (go) {
								action.onAction ();
						}
				}
		}
}
