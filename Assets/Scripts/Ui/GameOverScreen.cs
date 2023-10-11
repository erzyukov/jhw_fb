#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace Game
{
    public class GameOverScreen : MonoBehaviour
    {
		[SerializeField] private TextMeshProUGUI _scoreField;
		[SerializeField] private LevelScore _levelScore;
		[SerializeField] private Button _restartButton;
		[SerializeField] private Button _quitButton;

		private void Awake()
		{
			_restartButton.onClick.AddListener(OnRestartButtonClick);
			_quitButton.onClick.AddListener(OnQuitButtonClick);
		}

		private void OnEnable()
		{
			_scoreField.text = _levelScore.Score.ToString();
		}

		private void OnDestroy()
		{
			_restartButton.onClick.RemoveListener(OnRestartButtonClick);
			_quitButton.onClick.RemoveListener(OnQuitButtonClick);
		}

		private void OnRestartButtonClick()
		{
			int currentScene = 0;
			SceneManager.LoadScene(currentScene);
		}

		private void OnQuitButtonClick()
		{
#if UNITY_EDITOR
			EditorApplication.ExitPlaymode();
#else
			Application.Quit();
#endif
		}
	}
}
