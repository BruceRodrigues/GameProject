//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.33440
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;
public abstract class ITangible : MonoBehaviour
{
		public Transform transform;
		protected int hp;
		protected int damage;
		protected IWeapon weapon;

		public ITangible (int hp, int damage)
		{
				this.hp = hp;
				this.damage = damage;
		}

		public ITangible (int hp, int damate, IWeapon weapon)
		{
				this.hp = hp;
				this.damage = damage;
				this.weapon = weapon;
		}

		public bool isDead ()
		{
				return this.hp <= 0;
		}

		public virtual void hit (int damage)
		{
				Debug.Log ("HIT" + this.hp);
				this.hp -= damage;
		}

		public void addWeapon (IWeapon weapon)
		{
				this.weapon = weapon;
		}

		public virtual void Start ()
		{
		}

		public abstract void Update ();

}
