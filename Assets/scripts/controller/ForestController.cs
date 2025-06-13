using ForestManagers;
using UnityEngine;

namespace Controller
{
    public class ForestController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f; // Скорость движения

        public bool IsRunning; // Движется ли персонаж
        private int prevVertical = 1;
        void Start()
        {

            
        }
        void Update()
        {
            Move();
        }

        void Move()
        {
            // Получаем ввод с WASD
            float moveX = Input.GetAxisRaw("Horizontal"); // A и D
            float moveZ = Input.GetAxisRaw("Vertical");   // W и S

            // Обновляем состояние бега
            IsRunning = !(moveX == 0 && moveZ == 0);
            
            AnimationController.Instance.SetRunning(IsRunning);
            if (moveZ != 0)
            {
                int vertical = moveZ <= 0 ? 1 : -1;
                if (vertical != prevVertical)
                {
                    prevVertical = vertical;
                    AnimationController.Instance.SetVertical(vertical);
                }
            }
            
            // Формируем вектор движения
            Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;
     

            // Перемещаем персонажа
            transform.Translate(moveDirection * (moveSpeed * Time.deltaTime), Space.World);
        }
    }
}