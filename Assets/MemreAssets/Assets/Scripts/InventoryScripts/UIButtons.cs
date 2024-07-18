using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons : MonoBehaviour
{
    public GameObject InvUI;
    public GameObject CraftUI;
    public GameObject EquipmentUI;
    public GameObject SkillUI;
    public void InvButtonClick()
    {
        InvUI.SetActive(true);
        EquipmentUI.SetActive(true);
    }

    public void CraftButtonClick()
    {
        SkillUI.SetActive(false);
        CraftUI.SetActive(true);
    }

    public void SkillButtonClick()
    {
        SkillUI.SetActive(true);
        CraftUI.SetActive(false);
    }


}
