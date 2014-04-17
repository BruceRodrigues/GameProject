using UnityEngine;
using System.Collections;

public sealed class InputEnum
{

		public readonly string name;

		public static readonly InputEnum JUMP = new InputEnum ("Jump");
		public static readonly InputEnum ROLL = new InputEnum ("Roll");

		public InputEnum (string name)
		{
				this.name = name;
		}

}
