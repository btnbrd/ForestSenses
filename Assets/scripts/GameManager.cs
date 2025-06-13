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

    private void Awake()
    {
        Instance = this;
        treeInteraction = FindObjectOfType<InteractableDetector>();
    }


    public void StartPrecisionGame()
    {
        precisionGame.gameObject.SetActive(true);
        precisionGame.StartGame();
    }

    public void EndPrecisionGame()
    {
        treeInteraction.isInPrecisionGame = false;
    }

    public void ShowInteractableTip(bool isActive)
    {
        Debug.Log(isActive);
        treeTip.gameObject.SetActive(isActive);
    }
}