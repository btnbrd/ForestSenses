using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableDetector : MonoBehaviour
{
    [SerializeField] private float interactRange = 3;
    public bool isInPrecisionGame;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isInPrecisionGame && IsTreeInRange())
        {
            isInPrecisionGame = true;
            GameManager.Instance.StartPrecisionGame();
        }
    }

    private bool IsTreeInRange(float delta = 0)
    {
        var hitColliders = Physics.OverlapSphere(transform.position, interactRange - delta);
        foreach (var hit in hitColliders)
        {
            if (hit.CompareTag("Tree"))
            {
                return true;
            }
        }

        return false;
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
            GameManager.Instance.ShowInteractableTip(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            Debug.Log("Exited tree " + IsTreeInRange());
            if (!IsTreeInRange(0.01f))
            {
                GameManager.Instance.ShowInteractableTip(false);
            }
        }
    }
}