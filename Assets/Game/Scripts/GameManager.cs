using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using ForestManagers;
using Game.Scripts.Rubka;
using UnityEngine;

[DefaultExecutionOrder((-1))]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private PrecisionGame precisionGame;
    [SerializeField] private GameObject treeTip;
    private InteractableDetector treeInteraction;
    [SerializeField] private Animator animator;




    private void Awake()
    {
        Instance = this;
        treeInteraction = FindObjectOfType<InteractableDetector>();
    }

    private void Start()
    {
        
    }

    public void StartPrecisionGame(GameObject tree)
    {
        Debug.Log("Starting Precision Game");
        ControlManager.Instance.SwitchControl(false);
        precisionGame.StartGame(tree);
        
        
    }


    public void EndPrecisionGame()
    {
        Debug.Log($"called end precision game {treeInteraction.isInPrecisionGame}");
        treeInteraction.isInPrecisionGame = false;
        ControlManager.Instance.SwitchControl(true);
    }


}