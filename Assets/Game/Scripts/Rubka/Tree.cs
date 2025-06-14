using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Rubka
{
    public class Tree : MonoBehaviour
    {
        public string ID { get; private set; }
        private void Awake()
        {
            ID = System.Guid.NewGuid().ToString();
        }
    }
}