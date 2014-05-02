using UnityEngine;
using System.Collections;

public class ThrustWeapon : IWeapon
{

		public ThrustWeapon (int damage, int durability) : base(damage, durability, WeaponType.THRUST)
		{

		}

		// Use this for initialization
		public override void Start ()
		{
				this.damage = 10;
	
		}
	
		// Update is called once per frame
		public override void Update ()
		{
	
		}
}
