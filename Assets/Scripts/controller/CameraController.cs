using UnityEngine;

namespace Controller

{
    public class CameraController:MonoBehaviour
    {
        [SerializeField] private Transform target; // Цель (персонаж)
        [SerializeField] private float height = 10f; // Высота камеры над персонажем
        [SerializeField] private float distance = 10f; // Расстояние от камеры до персонажа
        [SerializeField] private float smoothSpeed = 2f; // Скорость сглаживания движения
        [SerializeField] private Vector3 offset = new Vector3(0f, 0f, 0f); // Смещение относительно персонажа

        private Vector3 _velocity; // Для SmoothDamp

        void Start()
        {
            // Проверяем наличие цели
            if (target == null)
            {
                Debug.LogError("Target for TopDownCamera is not assigned!");
                return;
            }

            // Устанавливаем начальную позицию камеры
            Vector3 targetPosition = target.position + offset + new Vector3(0f, height, -distance);
            transform.position = targetPosition;
            transform.LookAt(target.position + offset);
        }

        void LateUpdate()
        {
   

            // Целевая позиция камеры
            Vector3 targetPosition = target.position + offset + new Vector3(0f, height, -distance);

            // Плавное перемещение камеры
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

            // Камера смотрит на персонажа
            transform.LookAt(target.position + offset);

        }
    }
}