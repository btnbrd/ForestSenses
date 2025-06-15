using UnityEngine;
using ForestManagers;
using System.Collections;

namespace Controller
{
    public class ForestController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f; // Скорость движения

        private float speedUpgradeMultiplier;

        private Coroutine _currentBoost;


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
            {
                AnimationController.Instance.SetRunning(true);
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
                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }
                else if (moveX < 0)
                {
                    transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                }
            }
            else
            {
                AnimationController.Instance.SetHorizontal(false);
            }

            // Формируем вектор движения
            Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;


            // Перемещаем персонажа
            transform.Translate(moveDirection * (moveSpeed * Time.deltaTime), Space.World);
        }
        
        public void ApplyBoost(float duration)
        {
            if (_currentBoost != null)
            {
                StopCoroutine(_currentBoost);
            }
            
            _currentBoost = StartCoroutine(BoostEffect(duration));
        }

        IEnumerator BoostEffect(float boostDuration)
        {
            moveSpeed *= 2f;

            yield return new WaitForSeconds(boostDuration);

            moveSpeed *= 0.5f;
        }
    }
}