using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField] private Button triggerButton; // UI-кнопка
    [SerializeField] private AudioClip screamClip; // Звуковой клип скримера
    [SerializeField] private string sceneToLoad = "NextScene"; // Имя сцены
    [SerializeField] private AudioSource audioSource; // Источник звука

    private bool isLoading; // Флаг для предотвращения множественных вызовов

    void Start()
    {
        if (triggerButton == null)
        {
            Debug.LogError("Trigger Button is not assigned!");
            return;
        }

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

        // Добавляем слушатель на кнопку
        triggerButton.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (!isLoading)
        {
            isLoading = true;
            StartCoroutine(PlayScreamAndLoadScene());
        }
    }

    private IEnumerator PlayScreamAndLoadScene()
    {
        if (audioSource != null && screamClip != null)
        {
            audioSource.PlayOneShot(screamClip);
            yield return new WaitForSeconds(screamClip.length); // Ждём окончания звука
        }

        SceneManager.LoadScene(sceneToLoad);
    }

    void OnDestroy()
    {
        // Удаляем слушатель при уничтожении объекта
        if (triggerButton != null)
        {
            triggerButton.onClick.RemoveListener(OnButtonClick);
        }
    }
}
