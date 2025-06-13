using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class TimerController : MonoBehaviour
{
 
    [SerializeField] private string sceneToLoad = "NextScene"; // Имя сцены
    [SerializeField] private int runDurationSeconds = 60;
    [SerializeField] private TextMeshProUGUI timerText; 
    
    private int timeRemaining;
    private bool isLoading = false; // Флаг для предотвращения множественных вызовов

    void Start()
    {
        
        timeRemaining = runDurationSeconds;
        UpdateTimerDisplay();
        // Добавляем слушатель на кнопку
        StartCoroutine(TimerCoroutine());
    }

   


    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f); // Минуты
        int seconds = Mathf.FloorToInt(timeRemaining % 60f); // Секунды
       
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Формат MM:SS
    }
    private IEnumerator TimerCoroutine()
    {
        while (timeRemaining > 0 && !isLoading)
        {
            yield return new WaitForSeconds(1); // Ждём 1 секунду
            timeRemaining -= 1; // Уменьшаем на 1 секунду
            UpdateTimerDisplay(); // Обновляем UI
        }

        // После окончания таймера
        yield return StartCoroutine(PlayScreamAndLoadScene());
    }
    
    private IEnumerator PlayScreamAndLoadScene()
    {
        if (SoundController.Instance == null)
        {
            Debug.LogError("No sound controller found");
        }
        SoundController.Instance.PlayScream();
        yield return new WaitForSeconds(SoundController.Instance.GetScreamClipLength()); // Ждём окончания звука
        

        SceneManager.LoadScene(sceneToLoad);
        yield break;
    }

    
}
