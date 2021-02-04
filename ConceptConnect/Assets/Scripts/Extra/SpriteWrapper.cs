using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// WOLF_DEV
/// Used to wrap together Concepts and Sprites.
/// </summary>
public class SpriteWrapper{

    /// <summary>
    /// The Sprite
    /// </summary>
    public Sprite SpriteObj;
    /// <summary>
    /// The index(used to compare for clean non GB Collection)
    /// </summary>
    public int ConceptIndex;
    /// <summary>
    /// Here for.. debug/If you want to display/track what concepts are active or removed.
    /// </summary>
    public string ConceptString;

    /// <summary>
    /// Concept is set automatically
    /// </summary>
    /// <param name="sprite"></param>
    public SpriteWrapper(Sprite sprite)
    {
        SpriteObj = sprite;
        ConceptIndex = GetConceptIndex(SpriteObj, out ConceptString);
    }
    /// <summary>
    /// Public and static incase you want to assign values out side of creation.
    /// </summary>
    /// <param name="sprite">original sprite</param>
    /// <param name="con">String of the concept</param>
    /// <returns>Index of concept used to compare.</returns>
    public static int GetConceptIndex(Sprite sprite, out string con)
    {
        for (int i = 0; i < Concepts.CardConceptStr.Length; i++)
        {
            //Comparing CardConcept.cs/CardConceptsStr's
            //With the name of the sprite
            //Sprite names are from naming of the file itself.
            //::WARNING:: This will break if file names are not the concepts/same as CardConcept.cs
            if (sprite.name.Contains(Concepts.CardConceptStr[i]))
            {            
                con = Concepts.CardConceptStr[i];             
                return i;
            }

        }
        throw new UnityException("Card is not in CardConcepts.cs : Cardnames = " + sprite.name);
        //return -1;//ERROR LOG>
    }
}
