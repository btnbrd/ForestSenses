using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCompassController : MonoBehaviour
{
    [SerializeField] GameObject compassItself;
    [SerializeField] Transform lookTarget;

    void Start()
    {
        compassItself.SetActive(Inventory.Instance.inventoryManager.items[ItemType.Compass].Count > 0);
    }

    void Update()
    {
        compassItself.transform.LookAt(lookTarget);
    }
}
