using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Rubka
{
    public class TreeController : MonoBehaviour
    {
        public string ID { get; private set; }

        private void Awake()
        {
            ID = gameObject.name + "_" + transform.position.ToString("F2");
            // Проверяем, срублено ли дерево
            if (TreeManager.Instance.CheckChopped(ID))
            {
                gameObject.SetActive(false);
            }
        }


    }
}