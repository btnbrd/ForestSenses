using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableDetector : MonoBehaviour
{
    [SerializeField] private float interactRange = 3;
    [SerializeField] private float razmaxTime = 1f; // Время поворота (замаха)
    public bool isInPrecisionGame;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isInPrecisionGame && IsTreeInRange())
        {
            isInPrecisionGame = true;
            var hit = GetTreeInRange();
            StartCoroutine(RazmaxCoroutine(hit.transform));
        }
    }

    private Collider GetTreeInRange(float delta = 0)
    {
        var hitColliders = Physics.OverlapSphere(transform.position, interactRange - delta);
        foreach (var hit in hitColliders)
        {
            if (hit.CompareTag("Tree"))
            {
                return hit;
            }
        }

        return null;
    }

    private bool IsTreeInRange(float delta = 0)
    {
        return !ReferenceEquals(GetTreeInRange(delta), null);
    }


    private IEnumerator RazmaxCoroutine(Transform tree)
    {
        Debug.Log("Hello");
        Quaternion startRotation = transform.parent.rotation;
        Quaternion targetRotation = startRotation * Quaternion.Euler(0f, 180f, 0f);

        float elapsedTime = 0f;

        while (elapsedTime < razmaxTime)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / razmaxTime; // Прогресс от 0 до 1
            transform.parent.rotation = Quaternion.Lerp(startRotation, targetRotation, t);
            yield return null;
        }

        transform.parent.rotation = targetRotation;

        GameManager.Instance.StartPrecisionGame();
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
            if (!IsTreeInRange(0.08f))
            {
                GameManager.Instance.ShowInteractableTip(false);
            }
        }
    }
}