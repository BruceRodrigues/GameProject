﻿using UnityEngine;
using System.Collections;

public class StrikeWeapon : IWeapon
{

		public StrikeWeapon (int damage, int durability) : base(damage, durability, WeaponType.STRIKE)
		{

		}

		// Use this for initialization
		public override void Start ()
		{
	
		}
	
		// Update is called once per frame
		public override void Update ()
		{
	
		}
}
