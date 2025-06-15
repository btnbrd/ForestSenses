using System;
using UnityEngine;
using Controller;



namespace ForestManagers
{
    [DefaultExecutionOrder((-1))]
    public class ControlManager : MonoBehaviour
    {
        [SerializeField] private ForestController controller;

        public static ControlManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void  SwitchControl(bool state)
        {
            controller.enabled = state;
        }
    }
}