using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder((-1))]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private PrecisionGame precisionGame;
    private TreeInteraction treeInteraction;

    private void Awake()
    {
        Instance = this;
        treeInteraction = FindObjectOfType<TreeInteraction>();
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
}