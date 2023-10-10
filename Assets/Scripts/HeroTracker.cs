using UnityEngine;

namespace Game
{
    public class HeroTracker : MonoBehaviour
    {
		[SerializeField] private Hero _hero;
		[SerializeField] private float _xOffset;

		private void Update()
        {
			transform.position = new Vector3(_hero.transform.position.x - _xOffset, transform.position.y, transform.position.z);
        }
    }
}
