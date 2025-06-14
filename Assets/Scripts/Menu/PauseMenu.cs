using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private Button backButton; // Кнопка "Назад"
        [SerializeField] private Button menuButton; // Кнопка "В меню"
        [SerializeField] private Button exitButton; // Кнопка "Выйти"
        [SerializeField] private Canvas pauseCanvas;


        private bool _isPaused = false; // Флаг состояния паузы

        public bool IsPaused => _isPaused; // Для проверки состояния паузы в SelectController

        void Awake()
        {
            // Получаем Canvas с этого GameObject
            // pauseCanvas = GetComponent<Canvas>();
            if (pauseCanvas == null)
            {
                Debug.LogError("PauseMenu must be attached to a GameObject with a Canvas component!");
                enabled = false; // Отключаем скрипт, если Canvas не найден
                return;
            }

            // Проверяем, что кнопки назначены
            if (backButton == null || menuButton == null || exitButton == null)
            {
                Debug.LogError("One or more pause menu buttons are not assigned in PauseMenu!");
            }
        }

        void Start()
        {
            // Отключаем канвас паузы при старте
            pauseCanvas.enabled = false;
            backButton.onClick.AddListener(OnBackButton);
            exitButton.onClick.AddListener(OnExitButton);
            menuButton.onClick.AddListener(OnMenuButton);
        }

        void Update()
        {
            // Обрабатываем нажатие Esc
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_isPaused)
                {
                    ResumeGame(); // Повторное нажатие Esc = "Назад"
                }
                else
                {
                    PauseGame();
                }
            }
        }

        private void PauseGame()
        {
            _isPaused = true;
            Time.timeScale = 0f; // Приостанавливаем время
            pauseCanvas.enabled = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            // otherUI.SetActive(false);
        }

        private void ResumeGame()
        {
            _isPaused = false;
            Time.timeScale = 1f; // Возобновляем время
            pauseCanvas.enabled = false;
            // otherUI.SetActive(true);
        }

        // Метод для кнопки "Назад"
        public void OnBackButton()
        {
            ResumeGame();
        }

        // Метод для кнопки "В меню"
        public void OnMenuButton()
        {
            Time.timeScale = 1f; // Сбрасываем время перед загрузкой сцены
            PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
            PlayerPrefs.Save();
            SceneManager.LoadScene("MainMenu");
        }

        // Метод для кнопки "Выйти"
        public void OnExitButton()
        {
            Debug.Log("Exiting application");
            Application.Quit();
            #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false; // Для тестирования в редакторе
            #endif
        }
    }
