using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed;
    
    [SerializeField] private Vector3 offset;
    
    void Start()
    {
        // Проверяем наличие цели
        if (target == null)
        {
            Debug.LogError("Target for TopDownCamera is not assigned!");
            return;
        }

        // Устанавливаем начальную позицию камеры
        Vector3 targetPosition = target.position + offset;
        transform.position = targetPosition;
        
    }

    void LateUpdate()
    {

        Vector3 targetPosition = target.position + offset;
        targetPosition.y = offset.y;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}

