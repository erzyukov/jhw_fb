using UnityEngine;

namespace Game
{
	[RequireComponent(typeof(Hero))]
    public class HeroCollisionHandler : MonoBehaviour
    {
		private Hero _hero;

		private void Start()
		{
			_hero = GetComponent<Hero>();
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			_hero.Die();
		}
	}
}