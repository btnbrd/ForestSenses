using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder((-1))]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private PrecisionGame precisionGame;
    [SerializeField] private GameObject treeTip;
    private InteractableDetector treeInteraction;
    [SerializeField] private Animator animator;
    [SerializeField] private float razmaxTime = 1f; // Время поворота (замаха)
    
    

    private void Awake()
    {
        Instance = this;
        treeInteraction = FindObjectOfType<InteractableDetector>();
    }


    public void StartPrecisionGame()
    {
        Debug.Log("Starting Precision Game");
        precisionGame.StartGame();
    }
    

    public void EndPrecisionGame()
    {
        Debug.Log($"called end precision game {treeInteraction.isInPrecisionGame}");
        treeInteraction.isInPrecisionGame = false;
    }

    public void ShowInteractableTip(bool isActive)
    {

        treeTip.gameObject.SetActive(isActive);
    }

    public void SetAnimatorTrigger(string trigger)
    {
        animator.SetTrigger(trigger);
    }
}