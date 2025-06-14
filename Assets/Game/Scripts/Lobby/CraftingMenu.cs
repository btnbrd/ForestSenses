using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingMenu : MonoBehaviour
{
    [SerializeField] GameObject consumablesMenu;
    [SerializeField] GameObject toolsMenu;
    [SerializeField] GameObject upgradesMenu;

    [SerializeField] GameObject craftingRecipeUIPrefab;
    [SerializeField] Transform consumablesCraftingRecipeUIParent;
    [SerializeField] Transform toolsCraftingRecipeUIParent;
    [SerializeField] Transform upgradesCraftingRecipeUIParent;

    List<CraftingBarController> craftingBarsControllers = new List<CraftingBarController>();

    void Awake()
    {
        OpenConsumables();
        PopulateMenus();
    }

    private void SetMenus(bool showConsumables, bool showTools, bool showUpgrades)
    {
        consumablesMenu.SetActive(showConsumables);
        toolsMenu.SetActive(showTools);
        upgradesMenu.SetActive(showUpgrades);
    }

    // Триггерится по кнопке.
    public void OpenConsumables()
    {
        SetMenus(true, false, false);
    }

    // Триггерится по кнопке.
    public void OpenTools()
    {
        SetMenus(false, true, false);
    }

    // Триггерится по кнопке.
    public void OpenUpgrades()
    {
        SetMenus(false, false, true);
    }

    GameObject MakeCraftingRecipeUI(CraftingRecipe recipe)
    {
        var ui = Instantiate(craftingRecipeUIPrefab);
        ui.transform.localScale = new Vector3(1, 1, 1);
        craftingBarsControllers.Add(ui.GetComponent<CraftingBarController>());
        ui.GetComponent<CraftingBarController>().Init(this, recipe);
        return ui;
    }

    void PopulateMenus()
    {
        foreach (var recipe in ConstantsAndConfigs.ConsumablesCraftingRecipes)
        {
            var recipeUI = MakeCraftingRecipeUI(recipe);
            recipeUI.transform.SetParent(consumablesCraftingRecipeUIParent, false);
        }

        foreach (var recipe in ConstantsAndConfigs.ToolsCraftingRecipes)
        {
            var recipeUI = MakeCraftingRecipeUI(recipe);
            recipeUI.transform.SetParent(toolsCraftingRecipeUIParent, false);
        }

        foreach (var recipe in ConstantsAndConfigs.UpgradesCraftingRecipes)
        {
            var recipeUI = MakeCraftingRecipeUI(recipe);
            recipeUI.transform.SetParent(upgradesCraftingRecipeUIParent, false);
        }
    }

    public void TriggerCraftabilityUpdate()
    {
        foreach (var ctrl in craftingBarsControllers)
        {
            ctrl.CheckCraftability();
        }
    }
}
