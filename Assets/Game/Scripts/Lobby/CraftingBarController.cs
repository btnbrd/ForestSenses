using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CraftingBarController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;
    [SerializeField] private GameObject insufficientResourcesIndicator;
    [SerializeField] private GameObject doCraftText;
    [SerializeField] private Button craftButton;
    [SerializeField] private Transform inputItemsSpritesParent;
    [SerializeField] private Transform outputItemSpriteParent;
    [SerializeField] private GameObject itemSpritePrefab;
    [SerializeField] private float inputItemSpacing = 120;

    private CraftingRecipe recipe;
    private CraftingMenu menu;


    private bool CanCraft()
    {
        return HelperFuncs.IsListContainedInDictionary(recipe.input, Inventory.Instance.inventoryManager.items);
    }

    // Триггерится по кнопке.
    public void DoCraft()
    {
        Debug.Log("craft!!!!!");
        if (!CanCraft())
        {
            Debug.Log("nonono, can't craft");
            return;
        }

        foreach (var input in recipe.input)
        {
            for (int i = 0; i < input.Item2; ++i)
            {
                Inventory.Instance.inventoryManager.items[input.Item1].RemoveAt(0);
            }
        }

        Inventory.Instance.inventoryManager.items[recipe.output].Add(Inventory.CreateItem(recipe.output));
        Inventory.Instance.inventoryManager.Save();

        menu.TriggerCraftabilityUpdate();
    }

    public void Init(CraftingMenu menu, CraftingRecipe recipe)
    {
        this.menu = menu;
        this.recipe = recipe;

        itemNameText.text = Inventory.CreateItem(recipe.output).ItemName();
        itemDescriptionText.text = Inventory.CreateItem(recipe.output).ItemDescription();
        CheckCraftability();

        var outputSprite = Instantiate(itemSpritePrefab);
        outputSprite.GetComponent<Image>().sprite = Inventory.CreateItem(recipe.output).ItemIcon();
        outputSprite.GetComponent<ItemIconQuantityTextProvider>().GetText().text = "";
        outputSprite.transform.SetParent(outputItemSpriteParent);
        outputSprite.transform.localPosition = new Vector3();

        for (int i = 0; i < recipe.input.Count; ++i)
        {
            var inputSprite = Instantiate(itemSpritePrefab);
            inputSprite.GetComponent<Image>().sprite = Inventory.CreateItem(recipe.input[i].Item1).ItemIcon();
            inputSprite.GetComponent<ItemIconQuantityTextProvider>().GetText().text = recipe.input[i].Item2.ToString();
            inputSprite.transform.SetParent(inputItemsSpritesParent);
            inputSprite.transform.localPosition = new Vector3(i * inputItemSpacing, 0, 0);
        }

        inputItemsSpritesParent.position -= new Vector3(recipe.input.Count * inputItemSpacing / 2f, 0, 0);
    }

    public void CheckCraftability()
    {
        bool canCraft = CanCraft();
        insufficientResourcesIndicator.SetActive(!canCraft);
        doCraftText.SetActive(canCraft);
        craftButton.interactable = canCraft;
    }
}
