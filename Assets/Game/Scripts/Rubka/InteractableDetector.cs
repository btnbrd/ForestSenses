using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableDetector : MonoBehaviour
{
    [SerializeField] private float interactRange = 3;

    public bool isInPrecisionGame;
    private bool _isTreeInRange = false;

    public Collider tree;
    // [SerializeField] private Animator animator;

    private SphereCollider _sphereCollider;

    private void Start()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _sphereCollider.radius = interactRange;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isInPrecisionGame && IsTreeInRange())
        {
            Debug.Log("E in interactable pressed, start game");
            isInPrecisionGame = true;
            var hit = GetTreeInRange();
            GameManager.Instance.StartPrecisionGame(hit.gameObject);
        }
    }

    private Collider GetTreeInRange(float delta = 0)
    {
        // var hitColliders = Physics.OverlapSphere(transform.position, interactRange - delta);
        // foreach (var hit in hitColliders)
        // {
        //     if (hit.CompareTag("Tree"))
        //     {
        //         return hit;
        //     }
        // }
        //
        // return null;
        return tree;
    }

    private bool IsTreeInRange(float delta = 0)
    {
        // return !ReferenceEquals(GetTreeInRange(delta), null);
        return _isTreeInRange;
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
            _isTreeInRange = true;
            GameManager.Instance.ShowInteractableTip(_isTreeInRange);
            tree = collision;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            _isTreeInRange = false;
            // if (!IsTreeInRange(0.08f))
            // {
            tree = null;
            GameManager.Instance.ShowInteractableTip(_isTreeInRange);
            // }
        }
    }
}