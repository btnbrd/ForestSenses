using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class TimerController : MonoBehaviour
{
 
    [SerializeField] private AudioClip screamClip; // Звуковой клип скримера
    [SerializeField] private string sceneToLoad = "NextScene"; // Имя сцены
    [SerializeField] private AudioSource audioSource; // Источник звука
    [SerializeField] private int runDurationSeconds = 60;
    [SerializeField] private TextMeshProUGUI timerText; 
    
    private int timeRemaining;
    private bool isLoading = false; // Флаг для предотвращения множественных вызовов

    void Start()
    {
      

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogError("AudioSource component not found on this GameObject!");
            }
        }

        if (screamClip == null)
        {
            Debug.LogError("Scream AudioClip is not assigned!");
        }
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
            yield return new WaitForSecondsRealtime(1); // Ждём 1 секунду
            timeRemaining -= 1; // Уменьшаем на 1 секунду
            UpdateTimerDisplay(); // Обновляем UI
        }

        // После окончания таймера
        yield return StartCoroutine(PlayScreamAndLoadScene());
    }
    
    private IEnumerator PlayScreamAndLoadScene()
    {
       
        if (audioSource != null && screamClip != null)
        {
            audioSource.PlayOneShot(screamClip);
            yield return new WaitForSeconds(screamClip.length); // Ждём окончания звука
        }

        SceneManager.LoadScene(sceneToLoad);
        yield break;
    }

    
}
