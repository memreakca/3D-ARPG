using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkillFunctionality : MonoBehaviour
{   
    PlayerSkill playerSkill;

    Skill skill1;
    Skill skill2;
    Skill skill3;
    Skill rangedskill1;
    Skill rangedskill2;
    Skill rangedskill3;

    public AudioClip Skill3Swing;
    public AudioClip ranged2cast;

    public bool isFlaming;

    public PlayerSwordDamage playerSwordDamage;
    BarScripts barScripts;
    public Vector3 cursorPosition;
    public Vector3 mousePosition;
    public Animator animator;
    private void Start()
    {
        playerSwordDamage = PlayerAttackCombo.main.sword.GetComponent<PlayerSwordDamage>();

        animator = GetComponent<Animator>();
        barScripts = BarScripts.Instance;
        playerSkill = GetComponent<PlayerSkill>();
        skill1 = playerSkill.skill1;
        skill2 = playerSkill.skill2;
        skill3 = playerSkill.skill3;
        rangedskill1 = playerSkill.rangedskill1;
        rangedskill2 = playerSkill.rangedskill2;
        rangedskill3 = playerSkill.rangedskill3;
    }
    private void Update()
    {
        mousePosition = Input.mousePosition;
        if(isFlaming == true)
        {
            CharacterMovement.main.LookAtMouse();
        }
        ResetCooldowns();

        if(CharacterMovement.main.onMelee == true)
        {
            UpdateCooldownUI(skill1, barScripts.SetCooldownSkill1);
            UpdateCooldownUI(skill2, barScripts.SetCooldownSkill2);
            UpdateCooldownUI(skill3, barScripts.SetCooldownSkill3);
        }
        else
        {
            UpdateCooldownUI(rangedskill1, barScripts.SetCooldownRangedSkill1);
            UpdateCooldownUI(rangedskill2, barScripts.SetCooldownRangedSkill2);
            UpdateCooldownUI(rangedskill3, barScripts.SetCooldownRangedSkill3);
        }


    }
    
    private void UpdateCooldownUI(Skill skill, Action<Skill> updateUI)
    {
        updateUI(skill);
    }

    public void UseSkill1()
    {
        skill1.damage = skill1.baseDamage + skill1.level*(Player.main.STR * 0.4f); 
        if (skill1.level > 0 && skill1.cooldown <= 0 && Player.main.SP > skill1.manacost)
        {
            Player.main.SP -= skill1.manacost;
            playerSwordDamage.damageAmount = skill1.damage;
            CharacterMovement.main.LookAtMouse();
            animator.SetTrigger("MeleeSkill1");
            PlayerAttackCombo.main.isHitting = true;
            PlayerAttackCombo.main.canMove = false;
        }
        else return;

        skill1.SetCooldown();
    }

    public void UseSkill2()
    {
        skill2.damage = skill2.baseDamage + skill2.level*(Player.main.STR * 0.3f);
        if (skill2.level > 0 && skill2.cooldown <= 0 && Player.main.SP > skill2.manacost)
        {
            Player.main.SP -= skill2.manacost;
            playerSwordDamage.damageAmount = skill2.damage;
            CharacterMovement.main.LookAtMouse();
            animator.SetTrigger("MeleeSkill2");
            PlayerAttackCombo.main.isHitting = true;
            PlayerAttackCombo.main.canMove = false;
        }
        else return;

        skill2.SetCooldown();
    }
    public void UseSkill3() 
    {
        if (skill3.level > 0 && skill3.cooldown <= 0 && Player.main.SP > skill3.manacost )
        {
            Player.main.SP -= skill3.manacost;
            int duration = skill3.level + 5;
            animator.SetTrigger("MeleeSkill3");
            Player.main.BoostStats(duration);
            PlayerAttackCombo.main.isHitting = true;
            PlayerAttackCombo.main.canMove = false;
            Player.main.UpdateValues();
        }
        else return;

        skill3.SetCooldown();
        barScripts.SetCooldownSkill3(skill3);
    }
    public void UseRangedSkill1()
    {
        rangedskill1.damage = rangedskill1.baseDamage + rangedskill1.level * (Player.main.INT * 0.5f);
        if (rangedskill1.level > 0 && rangedskill1.cooldown <= 0 && Player.main.SP > rangedskill1.manacost) 
        {
            
            Player.main.SP -= rangedskill1.manacost;
            isFlaming = true;
            animator.SetTrigger("RangedSkill1");
            PlayerAttackCombo.main.canMove = false;
            PlayerRangedAttack.main.isAttacking = true;
        }

        else return;
        
        rangedskill1.SetCooldown();
    }
    public void UseRangedSkill2()
    {
        rangedskill2.damage = rangedskill2.baseDamage + rangedskill2.level * (Player.main.INT * 0.3f);
        if (rangedskill2.level > 0 && rangedskill2.cooldown <= 0 && Player.main.SP > rangedskill2.manacost)
        {
            AudioManager.instance.PlayForOnce(ranged2cast);
            Player.main.SP -= rangedskill2.manacost;
            CharacterMovement.main.LookAtMouse();
            setMousePosition();
            animator.SetTrigger("RangedSkill2");
            PlayerAttackCombo.main.canMove = false;
            PlayerRangedAttack.main.isAttacking = true;
        }

        else return;

        rangedskill2.SetCooldown();
    }
    public void UseRangedSkill3()
    {
        if (rangedskill3.level > 0 && rangedskill3.cooldown <= 0 && Player.main.SP > rangedskill3.manacost)
        {
            Player.main.SP -= rangedskill3.manacost;
            Player.main.barrierCount = rangedskill3.level + 1;
            animator.SetTrigger("RangedSkill3");
            PlayerAttackCombo.main.canMove = false;
            PlayerRangedAttack.main.isAttacking = true;
        }

        else return;

        rangedskill3.SetCooldown();
    }

    public void ActivateRangedSkill1()
    {
        playerSkill.rangedSkill1Flame.SetActive(true);  
    }
    public void DeactivateRangedSkill1()
    {
        playerSkill.rangedSkill1Flame.SetActive(false);
        isFlaming = false;
    }

    public void ActivateBarrier()
    {
        playerSkill.rangedSkill3Barrier.SetActive(true);
        Player.main.isBarrierOn = true;
    }

    public void skill3SwingSound()
    {
        AudioManager.instance.PlayForOnce(Skill3Swing);
    }
    public void setMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, float.MaxValue, PlayerRangedAttack.main.layerMask))
        {

            cursorPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);

        }
    }

    public void spawnFireRain()
    {
        GameObject fireRain = Instantiate(playerSkill.rangedSkill2Rain, cursorPosition, Quaternion.identity);
    }
    
    public void SetPlayerSkill(PlayerSkill _playerSkill)
    {
        playerSkill = _playerSkill;
    }
    private void ResetCooldowns()
    {
        ResetCooldown(skill1);
        ResetCooldown(skill2);
        ResetCooldown(skill3);
        ResetCooldown(rangedskill1);
        ResetCooldown(rangedskill2);
        ResetCooldown(rangedskill3);
    }

    public void ResetCooldown(Skill skill)
    {
        if (skill.cooldown > 0)
        {
            skill.cooldown -= Time.deltaTime;
            skill.cooldown = Mathf.Max(0, skill.cooldown);
        }
       
    }
}
