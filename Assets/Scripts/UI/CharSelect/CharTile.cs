using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/*
    The CharacterTile Scriptable Object that contains the name, sprite and voice line
    for when the chracter is selected.
*/

[CreateAssetMenu(fileName = "New Character Tile", menuName = "Character Tile")]
public class CharTile : ScriptableObject
{
    public string charName; // Name of Character
    public Sprite charImage; // Sprite of Character
    public AudioClip[] selectLine; // Voice Line when Character is Selected
    public string charIdle; // Animation that plays when Character is Hovered
    public string charReadyAnim; // Animation that plays when Character is Selected
    public AudioClip[] anouncerLine; // Voice Line for Ancouncer in Battle
}
