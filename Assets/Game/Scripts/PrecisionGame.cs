using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrecisionGame : MonoBehaviour
{
    [SerializeField] private Transform player;
    

    [SerializeField] private float  razmaxTime=0.3f;
    [SerializeField] private float  hitTime=0.25f;
    [SerializeField] private GameObject instance;
    
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
        instance.SetActive(false);
    }

    void Update()
    {
        if (inputAllowed)
        {
            MoveIndicator();

            if (Input.GetKeyDown(KeyCode.E))
            {
                inputAllowed = false;
                StartCoroutine(HitCoroutine());
                
            }
        }
    }
    
    void PlayHitSound()
    {
        
            SoundController.Instance.PlayHit();

    }
    
    public void StartGame()
    {
        Debug.Log("Called start game in PrecGame");
        StartCoroutine(RazmaxCoroutine());
        
    }
    private IEnumerator RazmaxCoroutine()
    {
        
        Quaternion startRotation = player.rotation;
        Quaternion targetRotation = startRotation * Quaternion.Euler(0f, 180f, 0f);
    
        float elapsedTime = 0f;
        GameManager.Instance.SetAnimatorTrigger("razmax");
        while (elapsedTime < razmaxTime)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / razmaxTime; // Прогресс от 0 до 1
            player.rotation = Quaternion.Lerp(startRotation, targetRotation, t);
            yield return null;
        }
    
        player.rotation = targetRotation;
        Debug.Log("Coroutine finished");
        instance.SetActive(true);
        inputAllowed = true;
    }

    private IEnumerator HitCoroutine()
    {
        GameManager.Instance.SetAnimatorTrigger("hit");
        
        yield return new WaitForSeconds(hitTime);
        PlayHitSound(); // Проигрываем звук
        CheckResult();
        EndGame();
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

    }

    void EndGame()
    {
        Debug.Log("Game ended");
        instance.SetActive(false);
        indicator.transform.position = indicatorPos;
        GameManager.Instance.EndPrecisionGame();
    }
}