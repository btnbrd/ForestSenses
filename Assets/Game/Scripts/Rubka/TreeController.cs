using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Serialization;

namespace Game.Scripts.Rubka
{
    public class TreeController : MonoBehaviour
    {
        public List<ItemType> loot;
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

        public (InventoryItem, bool) TakeHit()
        {
            if (loot.Count == 0)
            {
                return (null, true);
            }
            ItemType itm = loot[loot.Count - 1];
           
            loot.RemoveAt(loot.Count - 1);
            return (Inventory.CreateItem(itm), loot.Count==0);
        }


    }
}