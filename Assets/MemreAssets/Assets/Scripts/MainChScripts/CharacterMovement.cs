using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMovement : MonoBehaviour
{
    public static CharacterMovement main;
    [SerializeField] private LayerMask targetmask;
    public Cinemachine.CinemachineVirtualCamera virtualCamera;
    public AudioClip drawSword;

    public PlayerAttackCombo playerAttack;

    public float moveSpeed = 5.0f;
    private Rigidbody rb;

    private float rotationSpeed = 13f;
    private Animator animator;
    public bool isMoving;
    public Transform orientation;

    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject swordOnShoulder;

    public bool onMelee = false;
    public bool isEquipping;
    public bool isEquipped;


    private void Awake()
    {
        main = this;
    }

    private void Equip()
    {
        if (Input.GetKeyUp(KeyCode.Tab) && !isMoving)
        {
            isEquipping = true;
            animator.SetTrigger("EquipSword");
            if (!onMelee)
            {
                onMelee = true;
                animator.SetBool("onMelee", true);
            }
            else
            {
                onMelee = false;
                animator.SetBool("onMelee", false);
            }
        }
    }

    private void ActiveWeapon()
    {
        if (!isEquipped)
        {
            AudioManager.instance.PlayForOnce(drawSword);
            sword.SetActive(true);
            swordOnShoulder.SetActive(false);
            isEquipped = !isEquipped;
        }
        else
        {
            sword.SetActive(false);
            swordOnShoulder.SetActive(true);
            isEquipped = !isEquipped;
        }
    }

    public void Equipped()
    {
        isEquipping = false;
    }

    void Start()
    {
        playerAttack = GetComponent<PlayerAttackCombo>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (isEquipping || playerAttack.isHitting || !playerAttack.canMove || Player.main.isDead) { return; }
        CharacterMove();
        Equip();
    }

    public void CharacterMove()
    {
        if (playerAttack.isHitting) return;
        Vector3 cameraForward = virtualCamera.transform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        isMoving = Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f;

        animator.SetBool("isMoving", isMoving);
        Vector3 targetDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        if (isMoving)
        {
            rb.velocity = transform.forward * moveSpeed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
    
    public void LookAtMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, float.MaxValue, targetmask))
        {
            Vector3 cursorPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(cursorPosition);
        }
    }
}
