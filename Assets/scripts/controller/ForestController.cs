using UnityEngine;

namespace Controller
{
    public class ForestController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f; // Скорость движения
        private Animator _animator;
        public bool IsRunning; // Движется ли персонаж
        private int prevVertical = 1;
        void Start()
        {
            _animator = GetComponent<Animator>();
            
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
            
            _animator.SetBool("running", IsRunning);
            if (moveZ != 0)
            {
                int vertical = moveZ <= 0 ? 1 : -1;
                if (vertical != prevVertical)
                {
                    prevVertical = vertical;
                    _animator.SetInteger("vertical", vertical);
                }
            }
            
            // Формируем вектор движения
            Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;
     

            // Перемещаем персонажа
            transform.Translate(moveDirection * (moveSpeed * Time.deltaTime), Space.World);
        }
    }
}