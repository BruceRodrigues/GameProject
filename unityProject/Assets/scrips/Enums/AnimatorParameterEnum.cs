using UnityEngine;
using System.Collections;

public sealed class AnimatorParameterEnum
{

		public readonly string name;

		public static readonly AnimatorParameterEnum ROLL = new AnimatorParameterEnum ("roll");
		public static readonly AnimatorParameterEnum RUN = new AnimatorParameterEnum ("run");
		public static readonly AnimatorParameterEnum JUMP = new AnimatorParameterEnum ("jump");
		public static readonly AnimatorParameterEnum ATTACK = new AnimatorParameterEnum ("attack");


		public static readonly AnimatorParameterEnum DIALOGBOX_HEROIN = new AnimatorParameterEnum ("heroIn");

		public AnimatorParameterEnum (string name)
		{
				this.name = name;
		}
}
