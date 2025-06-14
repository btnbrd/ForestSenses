using System;
using UnityEngine;


namespace Game.Scripts.Rubka
{
    [DefaultExecutionOrder((-1))]
    public class TreeManager : MonoBehaviour
    {
        public static TreeManager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public void ChopTree(GameObject tree)
        {
            tree.SetActive(false);
            GameManager.Instance.ShowInteractableTip(false);
        }
    }
}