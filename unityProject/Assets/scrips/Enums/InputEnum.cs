using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class InputEnum
{

		public readonly string name;

		public static readonly InputEnum JUMP = new InputEnum ("Jump");
		public static readonly InputEnum ROLL = new InputEnum ("Roll");
		public static readonly InputEnum ATTACK = new InputEnum ("Attack");

		public InputEnum (string name)
		{
				this.name = name;
		}

}
