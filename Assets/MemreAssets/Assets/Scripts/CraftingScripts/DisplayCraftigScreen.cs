using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayCraftigScreen : MonoBehaviour
{
    [SerializeField] private ItemDatabaseObject itemDatabase;
    [SerializeField] private RecipeListObject recipeSO;
    [SerializeField] private GameObject recipePrefab;
    [SerializeField] RectTransform recipeListContent;
    [SerializeField] private GameObject ingredientsPrefab;
    [SerializeField] Image resultContent;
    [SerializeField] RectTransform ingredientsContent;
    [SerializeField] Button craftButton;
    private void Start()
    {
        resultContent.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        createRecipeTab();
    }
    private void createRecipeTab()
    {
        for (int i = 0; i < recipeSO.recipeList.Count ; i++)
        {
            var item = recipeSO.recipeList[i];
            var obj = Instantiate(recipePrefab, Vector3.zero, Quaternion.identity);
            obj.transform.SetParent(recipeListContent);
            obj.transform.GetComponentsInChildren<Image>()[1].sprite = item.uiDisplay;
            obj.transform.GetComponentInChildren<TextMeshProUGUI>().text = item.result.Name;

            var tempItem = item;
            obj.transform.GetComponent<Button>().onClick.AddListener(() => displayIngredients(tempItem));
        }
    }
    public void displayIngredients(CraftRecipeObject item)
    {
        resultContent.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        resultContent.sprite = item.uiDisplay;

        foreach (Transform child in ingredientsContent.transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < item.ingredients.Length; i++)
        {
            var ingobj = Instantiate(ingredientsPrefab, Vector3.zero, Quaternion.identity);
            ingobj.transform.SetParent(ingredientsContent);
            ingobj.transform.GetComponentsInChildren<Image>()[1].sprite = itemDatabase.Items[item.ingredients[i].item.Id].uiDisplay;
            ingobj.transform.GetComponentInChildren<TextMeshProUGUI>().text = item.ingredients[i].amount.ToString();
        }

        craftButton.onClick.RemoveAllListeners();
        craftButton.onClick.AddListener(() => item.Craft());
    }


}