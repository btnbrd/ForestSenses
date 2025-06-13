using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteraction : MonoBehaviour
{
    [SerializeField] private float interactRange = 3;
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
                    GameManager.Instance.StartPrecisionGame();
                }
            }
        }
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