using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemIconQuantityTextProvider : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI quantityText;

    public TextMeshProUGUI GetText()
    {
        return quantityText;
    }
}
