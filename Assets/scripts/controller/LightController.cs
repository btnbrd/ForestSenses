using UnityEngine;
using UnityEngine.Serialization;

namespace Controller
{
    public class LightController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float smoothSpeed = 2f;
        [SerializeField] private Vector3 offset = new Vector3(0f, 0f, 0f);


        [SerializeField] private float minLightIntensity = 0.5f;
        
        [SerializeField] private float intervalStable = 5f;
        [SerializeField] private float intervalStableVariation = 3f;
        [SerializeField] private float intervalFlicker = 1f;
        [SerializeField] private float baseIntensity = 4f;
        [SerializeField] private float rangeIntensity = 1f;

        [SerializeField] private float minRange = 15f; // Минимальный радиус света
        [SerializeField] private float maxRange = 40f; // Максимальный радиус света
        [SerializeField] private float minSpotAngle = 15f; // Минимальный радиус света
        [SerializeField] private float maxSpotAngle = 120f;
        [SerializeField] private float radiusChangeDuration = 60f; 

        private Light _spotLight;
        private float flickerTimer;
        private float flickerDuration;
        private bool isFlickering;
        private float radiusTimer; // Таймер для изменения радиуса

        void Start()
        {
            if (target == null)
            {
                Debug.LogError("Target for LightController is not assigned!");
                return;
            }

            _spotLight = GetComponent<Light>();
            if (_spotLight == null)
            {
                Debug.LogError("SpotLight component not found on this GameObject!");
            }

            Vector3 targetPosition = target.position + offset;
            transform.position = targetPosition;
            
            flickerTimer = intervalStable;
            radiusTimer = radiusChangeDuration;
        }

        void LateUpdate()
        {
            if (target == null) return;
            
            radiusTimer -= Time.deltaTime;
            radiusTimer = Mathf.Max(radiusTimer, 0);
            float t = 1f - (radiusTimer / radiusChangeDuration); // Прогресс от 0 до 1 за 60 секунд
            
            _spotLight.range = Mathf.Lerp(minRange, maxRange, t);
            _spotLight.spotAngle = Mathf.Lerp(minSpotAngle, maxSpotAngle, t);

            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
            
            
            flickerTimer -= Time.deltaTime;
            
            if (flickerTimer <= 0f)
            {
                isFlickering = true;
                flickerDuration = intervalFlicker; // Начинаем мерцание на 1 секунду
                flickerTimer = Random.Range(intervalStable-intervalStableVariation, intervalStable+intervalStableVariation); // Сбрасываем таймер для следующего цикла
            }

            if (isFlickering)
            {
                flickerDuration -= Time.deltaTime;

                // Мерцание: меняем интенсивность каждый кадр
               
                float flicker = Random.Range(-rangeIntensity, rangeIntensity);
                _spotLight.intensity = Mathf.Max(minLightIntensity, baseIntensity + flicker);

                if (flickerDuration <= 0f)
                {
                    isFlickering = false;
                    _spotLight.intensity = baseIntensity; // Восстанавливаем ровное освещение
                    // Debug.Log("Flicker ended");
                }
            }
            else
            {
                // _spotLight.intensity = baseIntensity; // Ровное освещение вне мерцания
            }
        }
       
    }
}