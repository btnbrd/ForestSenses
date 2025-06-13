using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class OpenUpgradesButton : MonoBehaviour
{
    public GameObject skillsPanel;

    public void ToggleSkillsPanelVisibility()
    {
        Assert.IsNotNull(skillsPanel);

        skillsPanel.SetActive(!skillsPanel.activeSelf);
    }
}
