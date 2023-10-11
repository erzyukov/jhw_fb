using UnityEngine;

namespace Game
{
    public class ScreensNavigator : MonoBehaviour
    {
		[SerializeField] private GameOverScreen _gameOverScreen;
		[SerializeField] private Hero _hero;

		private void Awake()
		{
			_hero.Died += OnPlayerDied;
			Time.timeScale = 1;
		}

		private void OnDestroy()
		{
			_hero.Died -= OnPlayerDied;
		}

		private void OnPlayerDied()
		{
			_gameOverScreen.gameObject.SetActive(true);
			Time.timeScale = 0;
		}
	}
}