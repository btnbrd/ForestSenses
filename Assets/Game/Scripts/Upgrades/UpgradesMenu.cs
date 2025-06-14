using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesMenu : MonoBehaviour
{
    InventoryManager inventoryManager;

    public TextMeshProUGUI minRadText;
    public TextMeshProUGUI maxRadText;
    public TextMeshProUGUI speedText;

    public TextMeshProUGUI minRadUpgradeButtonText;
    public TextMeshProUGUI maxRadUpgradeButtonText;
    public TextMeshProUGUI speedUpgradeButtonText;

    private float minRadius;
    private float maxRadius;
    private float speed;

    void Awake()
    {
        UpdateMinRadius();
        UpdateMaxRadius();
        UpdateSpeed();
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void UpgradeMinRadius()
    {
        if (inventoryManager.items.ContainsKey(ItemType.Berry)
            && inventoryManager.items[ItemType.Berry].Count >= 3)
        {
            inventoryManager.items[ItemType.Berry].RemoveRange(0, 3);
            PlayerPrefs.SetFloat(ConstantsAndConfigs.MIN_RADIUS_STAT_NAME, minRadius * ConstantsAndConfigs.UPGRADE_EXPONENTIAL_MULTIPLIER);
            PlayerPrefs.Save();
            UpdateMinRadius();
        }
    }

    public void UpgradeMaxRadius()
    {
        if (inventoryManager.items.ContainsKey(ItemType.Berry)
            && inventoryManager.items[ItemType.Berry].Count >= 3)
        {
            inventoryManager.items[ItemType.Berry].RemoveRange(0, 3);
            PlayerPrefs.SetFloat(ConstantsAndConfigs.MAX_RADIUS_STAT_NAME, maxRadius * ConstantsAndConfigs.UPGRADE_EXPONENTIAL_MULTIPLIER);
            PlayerPrefs.Save();
            UpdateMaxRadius();
        }
    }

    public void UpgradeSpeed()
    {
        if (inventoryManager.items.ContainsKey(ItemType.Berry)
            && inventoryManager.items[ItemType.Berry].Count >= 3)
        {
            inventoryManager.items[ItemType.Berry].RemoveRange(0, 3);
            PlayerPrefs.SetFloat(ConstantsAndConfigs.SPEED_STAT_NAME, speed * ConstantsAndConfigs.UPGRADE_EXPONENTIAL_MULTIPLIER);
            PlayerPrefs.Save();
            UpdateSpeed();
        }
    }

    private void UpdateMinRadius()
    {
        minRadius = PlayerPrefs.GetFloat(ConstantsAndConfigs.MIN_RADIUS_STAT_NAME, ConstantsAndConfigs.MIN_RADIUS_DEFAULT);
        minRadText.text = String.Format("Minimal light radius: {0}", minRadius);
        minRadUpgradeButtonText.text = String.Format("Upgrade! (cost: {0})", "3 beers");
    }

    private void UpdateMaxRadius()
    {
        maxRadius = PlayerPrefs.GetFloat(ConstantsAndConfigs.MAX_RADIUS_STAT_NAME, ConstantsAndConfigs.MAX_RADIUS_DEFAULT);
        maxRadText.text = String.Format("Maximal light radius: {0}", maxRadius);
        maxRadUpgradeButtonText.text = String.Format("Upgrade! (cost: {0})", "3 wines");
    }

    private void UpdateSpeed()
    {
        speed = PlayerPrefs.GetFloat(ConstantsAndConfigs.SPEED_STAT_NAME, ConstantsAndConfigs.SPEED_MULTIPLIER_DEFAULT);
        speedText.text = String.Format("Walk speed: {0}", speed);
        speedUpgradeButtonText.text = String.Format("Upgrade! (cost: {0})", "3 chocolate bars");
    }
}
