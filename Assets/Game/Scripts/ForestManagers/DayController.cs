using UnityEngine;
using UnityEngine.SceneManagement;

namespace ForestManagers
{
    public class DayController : MonoBehaviour
    {
        public static DayController Instance { get; private set; }
        private const string DayCountKey = "DayCount";
        public int dayCount = 0;
        [SerializeField] private GameObject gameOverScreen; // Экран итогов игры
        [SerializeField] private  int MaxDays = 5;
        private const string LobbySceneName = "LobbyScene";

        private void Awake()
        {
            // Singleton с DontDestroyOnLoad
            if (Instance == null)
            {
                Instance = this;
                // DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            
            gameOverScreen.SetActive(false);

            // Загружаем сохраненное количество дней
            dayCount = PlayerPrefs.GetInt(DayCountKey, 0);
        }

        private void Start()
        {
            // Увеличиваем счетчик дней при запуске сцены
            Debug.Log("DayController::Start()" + SceneManager.GetActiveScene().name);
            
            
            if (SceneManager.GetActiveScene().name == "SampleScene")
            {
                dayCount = PlayerPrefs.GetInt(DayCountKey, 0);
                if (dayCount >= MaxDays)
                {
                    ShowGameOverScreen();
                }
                dayCount++;
                PlayerPrefs.SetInt(DayCountKey, dayCount);
                PlayerPrefs.Save();
                Debug.Log($"Day: {dayCount}");

                
            }
        }

        private void ShowGameOverScreen()
        {
            if (gameOverScreen != null)
            {
                gameOverScreen.SetActive(true);
                Time.timeScale = 0f; // Останавливаем игру
                ControlManager.Instance.SwitchControl(false);
                Debug.Log("Game Over! Showing results screen.");
            }
            else
            {
                Debug.LogError("GameOverScreen is not assigned!");
            }
        }

        public void FinishDay()
        {
            if (dayCount >= MaxDays)
            {
                ShowGameOverScreen();
            }
            else
            {
                GoToLobby();
            }
        }
        // Метод для возврата в LobbyScene
        public void GoToLobby()
        {
            
            SceneManager.LoadScene(LobbySceneName);
        }

        // Метод для сброса количества дней (если нужно, например, для новой игры)
        public void ResetDays()
        {
            dayCount = 0;
            PlayerPrefs.SetInt(DayCountKey, 0);
            PlayerPrefs.Save();
        }
    }
}