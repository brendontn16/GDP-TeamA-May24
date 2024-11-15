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
    public AudioClip[] voiceLines; // Voice Lines
    public string[] voiceLineNames;
    public int characterSpeed;
    public CharacterManager PlayerTag;
    public CharacterManager OpponentTag;
    //Movement
    public Animator animations;
    //Light Attack
    public int lightAttackDamage;
    public float lightAttackPosY;
    public float lightAttackPosX;
    public float lightAttackFrameCount;
    public float lightAttackStartUpFrames;
    public float lightAttackRecoveryFrames;
    public Vector2 lightAttackHitboxScale;
    public float lightAttackHitStun;

    //Heavy Attack
    public int heavyAttackDamage;
    public float heavyAttackPosY;
    public float heavyAttackPosX;
    public float heavyAttackFrameCount;
    public float heavyAttackStartUpFrames;
    public float heavyAttackRecoveryFrames;
    public Vector2 heavyAttackHitboxScale;
    public float heavyAttackHitStun;
    //Special Move stuff here
    public int superAttackDamage;
    public float superAttackPosY;
    public float superAttackPosX;
    public float superAttackFrameCount;
    public float superAttackStartUpFrames;
    public float superAttackRecoveryFrames;
    public Vector2 superAttackHitboxScale;
    public float superAttackHitStun;
    //block
    public float blockPosY;
    public float blockPosX;
    public Vector3 blockBoxScale;
    public float blockRecoveryFrames;
}
