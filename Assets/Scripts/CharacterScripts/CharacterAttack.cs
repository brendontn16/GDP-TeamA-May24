using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
/* 
 *  all your attacks neatly organized in an object and use several combinations of Hitboxes for any of them.
 *  To do that you would need a script that strictly delegates 
 *  OnTriggerEnter calls to your active attack or something along those lines.
*/
public class CharacterAttack : MonoBehaviour
{
   // public Rigidbody2D character;
    public LayerMask groundLayer; //ground layer so we know if we're above ground
    public bool isBlocking = false;
    public string actionName = "Action";// action names
    
    private float frameCount; // counts duration of current attack
    private GameObject currentHitBox;
    //private SpriteRenderer hitBoxRenderer;
    
    protected Animator animator;
    protected bool shouldCombo;// if attack would combo into another
    protected int attackIndex;// the attack number in a combo string

    CharacterStateMachine characterState;
    public Hitbox hitbox;
    public CharacterManager controller;
    private SpriteRenderer hitBoxRenderer;

    private void Awake()
    {
        
    }
    void Start()
    {
        controller = GetComponent<CharacterManager>();

        hitBoxRenderer = GetComponent<SpriteRenderer>();
        if (hitBoxRenderer == null)
            Debug.LogError("Hitbox renderer not found!");

        // Find current hitbox
        currentHitBox = hitBoxRenderer.gameObject;
        if (currentHitBox == null)
            Debug.LogError("Current hitbox not found!");
        hitbox = GetComponent<Hitbox>();
        // controller.SetPlayerHealth();
        //controller.SetSuperMeter();
    }
    
    private void Update()
    {


    }
    void FixedUpdate()
    {
        
    }

    public void AttackLight(InputAction.CallbackContext context)
    {
        if (context.action.IsPressed())
        {
            //Debug.Log("AttackLightCalled");
            //frameCount = 0; // Reset frame count
            //if(keyPressed == false)
            hitbox.isAttacking = true;
            hitbox.SpawnHitbox(1);//attack type 1;
                                  //Debug.Log("light punch");

            characterState.SwitchState(characterState.AttackingState);
        }
    }
    public void AttackHeavy(InputAction.CallbackContext context)
    {
        if (context.action.IsPressed())
        {
            hitbox.isAttacking = true;
            hitbox.SpawnHitbox(2);
        }
    }
    /*
     * You need an input buffer. Store every input that happens in order for however many frames your longest input sequence will be.
     * Do this for every frame and every input for however many frames that is, and just get rid of the tail whenever you add a new input.
     * Then you look to see if the input buffer up through the last input matches any known moves. you should be recording like �back� �down + back� etc as inputs.
     * Note that presses can happen for multiple frames so you usually want to also buffer what you�re reading from the input buffer. 
     * In other words, have a number of frames that are allowed as holds between new inputs in the middle of series where anything 
     * below the threshold is considered part of the series (since inputs will not be exactly 1 frame each).
     * There are many ways to specifically implement this but that�s a pretty basic overview of the algorithm to get you started.
     */
    float StartFrames()
    {
        return 0;
    }
    float ActiveFrames()
    {
        return 0;
    }
    float RecoveryFrames()
    {
        return 0;
    }
    float HitStunFrames()
    {
        return 0;
    }
    float BlockStunFrames()
    {
        return 0;
    }
    float attack()
    {
        return 0;
    }
    string AttackProperty()
    {
        return "";
    }
}
