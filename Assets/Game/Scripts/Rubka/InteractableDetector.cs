// using System;
// using System.Collections;
using System.Collections.Generic;
// using Unity.VisualScripting;
using UnityEngine;

public class InteractableDetector : MonoBehaviour
{
    [SerializeField] private float interactRange = 3;
    [SerializeField] private GameObject interactTipPrefab; // Префаб с буквой "E"
    [SerializeField] private Vector3 offset = new Vector3(0, 2, 3); // Смещение над деревом

    public bool isInPrecisionGame;
    // private bool _isTreeInRange = false;

    public Collider tree;
    // [SerializeField] private Animator animator;

    private SphereCollider _sphereCollider;
    
    private GameObject _currentInteractTip; // Текущий экземпляр подсказки

    //
    // public List<Collider> _trees;
    // public List<Collider> berries;
    
    private Dictionary<string, GameObject> _interactTips = new Dictionary<string, GameObject>();

    // private void Start()
    // {
    //     // _sphereCollider = GetComponent<SphereCollider>();
    //     // _sphereCollider.radius = interactRange;
    //     // _trees = new List<Collider>();
    // }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isInPrecisionGame)
        {
            if (IsObjectInRange("Berry"))
            {
                CollectBerry();
                return;
            }

            Debug.Log(IsTreeInRange());
            if (IsTreeInRange() == false)
            {
                return;
            }

            Debug.Log("E in interactable pressed, start game");
            isInPrecisionGame = true;
            var hit = GetTreeInRange();
            GameManager.Instance.StartPrecisionGame(hit.gameObject);
        }
    }

    private void CollectBerry()
    {
        var berry = GetObjectInRange("Berry");
        berry.gameObject.SetActive(false);
        DestroyInteractTip(berry.gameObject.name);


        Inventory.Instance.CollectWithMouse(ItemType.BlueBerry);
    }


    private Collider GetObjectInRange(string objectTag, float delta = 0)
    {
     
        var hitColliders = Physics.OverlapSphere(transform.position, interactRange - delta);
        foreach (var hit in hitColliders)
        {
            if (hit.CompareTag(objectTag))
            {
                return hit;
            }
        }

        return null;
        // return _trees[0];
    }

    private bool IsObjectInRange(string objectTag, float delta = 0)
    {
        return !ReferenceEquals(GetObjectInRange(objectTag, delta), null);
    }

    private Collider GetTreeInRange(float delta = 0)
    {
        return GetObjectInRange("Tree", delta);
    }

    private bool IsTreeInRange(float delta = 0)
    {
        return !ReferenceEquals(GetTreeInRange(delta), null);
        // return _trees.Count > 0;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 0.5f, 1f, 0.3f); // Полупрозрачный синий
        var position = transform.position;
        Gizmos.DrawSphere(position, interactRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(position, interactRange);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            // _isTreeInRange = true;
        }

        if (_currentInteractTip == null)
        {
            CreateInteractTip(collision.gameObject);
        }
        
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            if (!IsTreeInRange(0.08f))
            {
                // tree = null;
                // _isTreeInRange = false;
                // GameManager.Instance.ShowInteractableTip(_isTreeInRange);
                // _trees.Remove(collision);
                // _isTreeInRange = _trees.Count == 0;
            }
        }
        DestroyInteractTip(collision.gameObject.name);
    }

    
 

    public void OnChopTree(GameObject treeIn)
    {
        DestroyInteractTip(treeIn.name);
    }
    

    
    private void CreateInteractTip(GameObject targetObject)
    {
        string objectName = targetObject.name;
        if (interactTipPrefab != null && !_interactTips.ContainsKey(objectName))
        {
            Vector3 pos = targetObject.transform.position + offset;
            pos.y = offset.y;
            GameObject tip = Instantiate(interactTipPrefab, pos, Quaternion.identity);
            tip.SetActive(true);
            _interactTips[objectName] = tip; // Добавляем подсказку в словарь
        }
    }

    private void DestroyInteractTip(string objectName)
    {
        if (_interactTips.TryGetValue(objectName, out GameObject tip) && tip != null)
        {
            Destroy(tip);
            _interactTips.Remove(objectName); // Удаляем из словаря
        }
    }
}