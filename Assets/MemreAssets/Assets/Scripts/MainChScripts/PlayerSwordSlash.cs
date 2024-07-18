using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordSlash : MonoBehaviour
{
    public GameObject Hit1Slash;
    public GameObject Hit2Slash;
    public GameObject Hit3Slash;
    public GameObject Skill1_1Slash;
    public GameObject Skill1_2Slash;
    public GameObject Skill2Slash;
    public void ActivateHit1Slash()
    {
        AudioManager.instance.PlayForOnce(PlayerAttackCombo.main.hit1swing);
        Hit1Slash.SetActive(true);
    }
    public void DeactivateHit1Slash()
    {
        Hit1Slash.SetActive(false);
    }
    ///-----------------------------------/
    public void ActivateHit2Slash()
    {
        AudioManager.instance.PlayForOnce(PlayerAttackCombo.main.hit2swing);
        Hit2Slash.SetActive(true);
    }
    public void DeactivateHit2Slash()
    {
        Hit2Slash.SetActive(false);
    }
    ///-----------------------------------/
    public void ActivateHit3Slash()
    {
        AudioManager.instance.PlayForOnce(PlayerAttackCombo.main.hit3swing);
        Hit3Slash.SetActive(true);
    }
    public void DeactivateHit3Slash()
    {
        Hit3Slash.SetActive(false);
    }
    ///-----------------------------------/
    public void ActivateSkill1_1Slash()
    {
        AudioManager.instance.PlayForOnce(PlayerAttackCombo.main.skill1swing1);
        Skill1_1Slash.SetActive(true);
    }
    public void DeactivateSkill1_1Slash()
    {
        Skill1_1Slash.SetActive(false);
    }
    ///-----------------------------------/
    public void ActivateSkill1_2Slash()
    {
        AudioManager.instance.PlayForOnce(PlayerAttackCombo.main.skill1swing2);
        Skill1_2Slash.SetActive(true);
    }
    public void DeactivateSkill1_2Slash()
    {
        Skill1_2Slash.SetActive(false);
    }
    ///-----------------------------------/
    public void ActivateSkill2Slash()
    {
        Skill2Slash.SetActive(true);
    }
    public void DeactivateSkill2Slash()
    {
        Skill2Slash.SetActive(false);
    }
}
