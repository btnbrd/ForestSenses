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
            var ctrl = tree.GetComponent<TreeController>();
            string treeID = ctrl.ID;
            PlayerPrefs.SetInt(treeID, 1);
            tree.SetActive(false);
            GameManager.Instance.ShowInteractableTip(false);

            var o = "";
            foreach (var item in ctrl.loot)
            {
                Inventory.Instance.inventoryManager.items[item].Add(Inventory.CreateItem(item));
                Inventory.Instance.inventoryManager.Save();
                o += item.ToString();
            }
            Debug.Log("Inventory: " + o + ", ");
        }

        public bool CheckChopped(string ID)
        {
            return PlayerPrefs.HasKey(ID);
        }
    }
}