using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCombo : MonoBehaviour
{
    public static PlayerAttackCombo main;
    private CharacterMovement chmov;
    [SerializeField] public GameObject sword;
    private BoxCollider SwordHitbox;
    public PlayerSwordDamage playerSwordDamage;

    private Animator animator;

    [SerializeField] public float hit1Damage;
    [SerializeField] public float hit2Damage;
    [SerializeField] public float hit3Damage;

    public AudioClip hit1swing;
    public AudioClip hit2swing;
    public AudioClip hit3swing;
    public AudioClip hit1;
    public AudioClip hit2;
    public AudioClip hit3;
    public AudioClip skill1swing1;
    public AudioClip skill1swing2;

    public bool canMove;
    public bool isHitting;
    public float timeSinceAttack;
    public float timeSinceHit;
    public int currentAttack = 1;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        playerSwordDamage = sword.GetComponent<PlayerSwordDamage>();
        SwordHitbox = sword.GetComponent<BoxCollider>();
        canMove = true;
        isHitting = false;
        animator = GetComponent<Animator>();
        chmov = GetComponent<CharacterMovement>();
    }

    private void Update()
    {
        if (chmov.isEquipping || isHitting)
        {
            timeSinceHit += Time.deltaTime;
            if (timeSinceHit > 4f)
            {
                ResetHit();
            }
            return;
        }

        timeSinceAttack += Time.deltaTime;
        Attack();
    }

    public void Attack()
    {
        if (!chmov.onMelee || Time.timeScale == 0) { return; }
        if (Input.GetMouseButton(0) && timeSinceAttack > 0.4f)
        {
            chmov.LookAtMouse();
            currentAttack++;
            canMove = false;
            isHitting = true;
            timeSinceHit = 0f; // Reset the hit timer
            chmov.isMoving = false;
            animator.SetBool("isMoving", false);

            if (currentAttack > 3)
            {
                currentAttack = 1;
            }

            if (timeSinceAttack > 1.0f)
            {
                currentAttack = 1;
            }

            animator.SetTrigger("MeleeAttack" + currentAttack);
            setComboDamage();
            Debug.Log(currentAttack.ToString() + " DMG" + playerSwordDamage.damageAmount.ToString());

            timeSinceAttack = 0f;
        }
    }

    public void setComboDamage()
    {
        if (currentAttack == 1)
        {
            AudioManager.instance.PlayForOnce(hit1);
            playerSwordDamage.damageAmount = hit1Damage + (Player.main.STR * 0.3f);
        }
        else if (currentAttack == 2)
        {
            AudioManager.instance.PlayForOnce(hit2);
            playerSwordDamage.damageAmount = hit2Damage + (Player.main.STR * 0.4f);
        }
        else if (currentAttack == 3)
        {
            AudioManager.instance.PlayForOnce(hit3);
            playerSwordDamage.damageAmount = hit3Damage + (Player.main.STR * 0.5f);
        }
    }

    public void ActivateSwordHitbox()
    {
        SwordHitbox.enabled = true;
    }

    public void DeactivateSwordHitbox()
    {
        SwordHitbox.enabled = false;
    }

    public void ResetHit()
    {
        isHitting = false;
        timeSinceHit = 0f; 
    }

    public void ResetMove()
    {
        canMove = true;
    }
}
