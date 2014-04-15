using UnityEngine;
using System.Collections;

public sealed class InputEnum
{

		public readonly string name;

		public static readonly InputEnum JUMP = new InputEnum ("Jump");

		public InputEnum (string name)
		{
				this.name = name;
		}

}
