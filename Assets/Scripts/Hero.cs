using UnityEngine;

namespace Game
{
	[RequireComponent (typeof (HeroMover))]
    public class Hero : MonoBehaviour
    {
		private HeroMover _heroMover;
		private int _score;

		private void Start ()
		{
			_heroMover = GetComponent<HeroMover>();
		}

		public void ResetHero()
		{
			_score = 0;
			_heroMover.ResetHero();
		}

		public void Die()
		{
			Time.timeScale = 0;
		}
	}
}
