using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioClip musicClip;
    [SerializeField] [Range(0f, 1f)] private float volume = 0.5f;
    
    private AudioSource _audioSource;

    void Awake()
    {
        // Set up the audio source
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = musicClip;
        _audioSource.loop = true;
        _audioSource.volume = volume;
        
        // Make this object persistent between scenes (optional)
        // DontDestroyOnLoad(gameObject);
        
        // Start playing
        _audioSource.Play();
    }

    // Quick volume control from other scripts
    public void SetVolume(float newVolume) => _audioSource.volume = newVolume;
}