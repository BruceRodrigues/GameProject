using UnityEngine;
using System.Collections;

public sealed class AnimatorParameterEnum
{

		public readonly string name;

		public static readonly AnimatorParameterEnum ROLL = new AnimatorParameterEnum ("roll");
		public static readonly AnimatorParameterEnum RUN = new AnimatorParameterEnum ("run");

		public AnimatorParameterEnum (string name)
		{
				this.name = name;
		}
}
