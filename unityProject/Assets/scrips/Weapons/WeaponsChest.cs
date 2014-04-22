//------------------------------------------------------------------------------
// This class contains all weapons that will be used in the game.
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Collections;


public class WeaponsChest
{

		public enum WeaponName
		{
				COMMON_SWORD,
				COMMON_SPEAR

		}

		private Hashtable weapons;

		private static WeaponsChest instance;

		private WeaponsChest ()
		{
				this.weapons = new Hashtable ();

				this.addAllSwords ();

				this.addAllSpears ();
		}

		public WeaponsChest getInstace ()
		{
				if (instance == null) {
						instance = new WeaponsChest ();
				}
				return instance;
		}

		private void addAllSwords ()
		{

		}

		private void addAllSpears ()
		{
				this.weapons.Add (WeaponName.COMMON_SPEAR, new ThrustWeapon (10, 100));
		}

		public IWeapon getWeapon (WeaponName name)
		{
				return (IWeapon)this.weapons [name];
		}
}

