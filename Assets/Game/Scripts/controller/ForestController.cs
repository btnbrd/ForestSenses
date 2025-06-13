using UnityEngine;

namespace Controller
{
    public class ForestController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f; // Скорость движения

        private float speedUpgradeMultiplier;


        public bool IsRunning; // Движется ли персонаж

        void Awake()
        {
            speedUpgradeMultiplier = PlayerPrefs.GetFloat(ConstantsAndConfigs.SPEED_STAT_NAME, ConstantsAndConfigs.SPEED_MULTIPLIER_DEFAULT);
        }

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
            
            
            if (moveZ != 0)
            {   AnimationController.Instance.SetRunning(true);
                int vertical = moveZ <= 0 ? 1 : -1;
                if (vertical != prevVertical)
                {
                    prevVertical = vertical;
                    AnimationController.Instance.SetVertical(vertical);
                }
            }
            else
            {
                AnimationController.Instance.SetRunning(false);
            }

            if (moveX != 0)
            {
                AnimationController.Instance.SetHorizontal(true);
                if (moveX > 0)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                } else if (moveX < 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
            
            // Формируем вектор движения
            Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;
     

            // Перемещаем персонажа
            transform.Translate(moveDirection * (moveSpeed * Time.deltaTime), Space.World);
        }
    }
}