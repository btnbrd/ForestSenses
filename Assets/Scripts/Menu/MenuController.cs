using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string nextScene;
    public void StartGame()
    {

        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
        SceneManager.LoadScene(nextScene); // Замени "GameScene" на имя твоей сцены
    }

    public void Start()
    {
  
    }

    public void OpenSettings()
    {
        Debug.Log("Открыть настройки (пока не реализовано)");
    }

    public void ExitGame()
    {
        Debug.Log("Выход из игры");
        Application.Quit();

        // Для проверки в редакторе
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}