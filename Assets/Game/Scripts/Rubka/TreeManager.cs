using System;
using UnityEngine;


namespace Game.Scripts.Rubka
{
    [DefaultExecutionOrder((-1))]
    public class TreeManager : MonoBehaviour
    {
        public static TreeManager Instance { get; private set; }
        private InteractableDetector _interactableDetector;
        private void Awake()
        {
            Instance = this;
            _interactableDetector = FindObjectOfType<InteractableDetector>();
        }

        public void HitTree(GameObject tree)
        {
            var ctrl = tree.GetComponent<TreeController>();
            string treeID = ctrl.ID;


            var(itm,  isLast)  = ctrl.TakeHit();

            if (itm != null)
            {
                Debug.Log($"{itm.ItemName()} collected");
            }
            if (isLast)
            {
                ChopTree(tree, ctrl);
            }
        }

        private void ChopTree(GameObject tree, TreeController trctrl)
        {
            PlayerPrefs.SetInt(trctrl.ID, 1);
            PlayerPrefs.Save();
            tree.SetActive(false);
            _interactableDetector.OnChopTree(tree);
        }
        

        public bool CheckChopped(string ID)
        {
            return PlayerPrefs.HasKey(ID);
        }
    }
}