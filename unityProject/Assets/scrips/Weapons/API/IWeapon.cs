using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class IWeapon : MonoBehaviour
{

		protected enum WeaponType
		{
				SLASH,
				STRIKE,
				THRUST
		}

		protected int damage;
		protected int durability;
		protected int currentDurability;
		protected WeaponType type;
		protected List<Rune> runes;

		protected IWeapon (int damage, int durability, WeaponType type)
		{
//				this.damage = damage;
				this.damage = 1;
				this.durability = this.currentDurability = durability;
				this.type = type;
				this.runes = new List<Rune> ();
		}

		protected IWeapon (int damage, int durability, WeaponType type, List<Rune> runes)
		{
				this.damage = damage;
				this.durability = this.currentDurability = durability;
				this.type = type;
				this.runes = runes;
		}

		public void addRune (Rune rune)
		{
				this.runes.Add (rune);
		}

		public int getDamage ()
		{
				return this.damage;
		}

		public int getDurability ()
		{
				return this.durability;
		}

		public int getCurrentDurability ()
		{
				return this.currentDurability;
		}

		public void OnTriggerEnter2D (Collider2D coll)
		{
				if (coll.gameObject.layer == LayerEnum.TANGIBLE.number) {
						ITangible tangible = Collider2D.FindObjectOfType<ITangible> ();
						tangible.hit (this.damage);
				}
		}

		// Use this for initialization
		public abstract void Start ();
	
		// Update is called once per frame
		public abstract void Update ();
}
