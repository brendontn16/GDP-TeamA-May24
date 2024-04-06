using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
// Character Specific Data
// Name, Animations, Movesets, 
// Scriptable Object

[CreateAssetMenu(fileName = "CharacterLoader", menuName = "CharacterLoader")]
public class CharacterDataLoader : ScriptableObject
{
    public string charName; // Name of Character
    public Sprite charImage; // Sprite of Character
    public AudioClip[] VoiceLine; // Voice Line when Character is Selected
    public int characterSpeed;
    public CharacterManager PlayerTag;
    public CharacterManager OpponentTag;
    //Movement
    public Animator ForwardWalkAnimator;
    public Animator BackwardWalkAnimator;
    public Animator BlockAnimator;
    public Animator IdleAnimator;
    public Animator JumpAnimator;
    public Animator CrouchAnimator;
    public Animator KnockdownAnimator;
    public Animator KnockoutAnimator;
    public Animator DamagedAnimator;
    //Light Attack
    public int lightAttackDamage;
    public float lightAttackPosY;
    public float lightAttackPosX;
    public float lightAttackFrameCount;
    public Vector2 lightAttackHitboxScale;
    public Animator LightAnimator;

    //Heavy Attack
    public int heavyAttackDamage;
    public float heavyAttackPosY;
    public float heavyAttackPosX;
    public float heavyAttackFrameCount;
    public Vector2 heavyAttackHitboxScale;
    public Animator HeavyAnimator;
    //Special Move stuff here

}
