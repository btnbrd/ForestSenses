using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteraction : MonoBehaviour
{
    [SerializeField] private float interactRange = 3;
    [SerializeField] private float razmaxTime = 1f; // Время поворота (замаха)
    public bool isInPrecisionGame;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isInPrecisionGame)
        {
            var hitColliders = Physics.OverlapSphere(transform.position, interactRange);
            foreach (var hit in hitColliders)
            {
                if (hit.CompareTag("Tree"))
                {
                    isInPrecisionGame = true;
                    StartCoroutine(RazmaxCoroutine(hit.transform));
                }
            }
        }
    }

    private IEnumerator RazmaxCoroutine(Transform tree)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = startRotation * Quaternion.Euler(0f, 180f, 0f);

        float elapsedTime = 0f;

        while (elapsedTime < razmaxTime)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / razmaxTime; // Прогресс от 0 до 1
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, t);
            yield return null; 
        }

        transform.rotation = targetRotation;

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
}