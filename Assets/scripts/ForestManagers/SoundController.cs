using UnityEngine;

[DefaultExecutionOrder((-1))]
public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; // Источник звука
    [SerializeField] private AudioClip screamClip; // Звуковой клип скримера
    [SerializeField] private AudioClip hitClip; // Звуковой клип удара
    public static SoundController Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogError("AudioSource component not found on SoundManager!");
            }
        }
    }

    public void PlayScream()
    {
        if (audioSource != null && screamClip != null)
        {
            audioSource.PlayOneShot(screamClip);
        }
        else
        {
            Debug.LogWarning("ScreamClip or AudioSource is not assigned in SoundManager!");
        }
    }

    public void PlayHit()
    {
        if (audioSource != null && hitClip != null)
        {
            audioSource.PlayOneShot(hitClip);
        }
        else
        {
            Debug.LogWarning("HitClip or AudioSource is not assigned in SoundManager!");
        }
    }

    // Возвращает длительность скримера для ожидания в корутине
    public float GetScreamClipLength()
    {
        return screamClip != null ? screamClip.length : 0f;
    }
}