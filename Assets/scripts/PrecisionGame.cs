using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrecisionGame : MonoBehaviour
{
    
    [SerializeField] private AudioClip hitSound; // Звуковой клип для нажатия E
    [SerializeField] private AudioSource audioSource; // Источник звука
    
    public RectTransform indicator; // Двигающийся индикатор
    public RectTransform hitZone; // Зона попадания
    public float speed = 300f; // Скорость движения

    private bool movingUp = true;
    private float minY;
    private float maxY;
    private bool inputAllowed;
    private Vector3 indicatorPos;

    void Start()
    {
        // Получаем границы по родителю
        RectTransform parent = indicator.parent.GetComponent<RectTransform>();
        float height = parent.rect.height;
        float halfHeight = height / 2f;
        minY = -halfHeight + indicator.rect.height / 2f;
        maxY = halfHeight - indicator.rect.height / 2f;
        indicatorPos = indicator.transform.position;
    }

    void Update()
    {
        if (inputAllowed)
        {
            MoveIndicator();

            if (Input.GetKeyDown(KeyCode.E))
            {
                inputAllowed = false;
                PlayHitSound(); // Проигрываем звук
                CheckResult();
            }
        }
    }
    
    void PlayHitSound()
    {
        if (audioSource != null && hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }
        else
        {
            Debug.LogError("no sound to play");
        }
    }
    

    public void StartGame()
    {
        gameObject.SetActive(true);
        inputAllowed = true;
    }

    void MoveIndicator()
    {
        float direction = movingUp ? 1 : -1;
        indicator.anchoredPosition += new Vector2(0f, direction * speed * Time.deltaTime);

        if (indicator.anchoredPosition.y >= maxY)
            movingUp = false;
        else if (indicator.anchoredPosition.y <= minY)
            movingUp = true;
    }

    void CheckResult()
    {
        float indBottom = indicator.anchoredPosition.y - indicator.rect.height / 2f;
        float indTop = indicator.anchoredPosition.y + indicator.rect.height / 2f;

        float zoneBottom = hitZone.anchoredPosition.y - hitZone.rect.height / 2f;
        float zoneTop = hitZone.anchoredPosition.y + hitZone.rect.height / 2f;

        if (indTop >= zoneBottom && indBottom <= zoneTop)
        {
            Debug.Log("✅ УСПЕХ!");
            // Взаимодействие успешно
        }
        else
        {
            Debug.Log("❌ ПРОМАХ!");
        }

        EndGame();
    }

    void EndGame()
    {
        gameObject.SetActive(false);
        indicator.transform.position = indicatorPos;
        GameManager.Instance.EndPrecisionGame();
    }
}