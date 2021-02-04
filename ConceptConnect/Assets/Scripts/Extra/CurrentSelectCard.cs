using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// WOLF_DEV
/// The Currently selected card, Holds animation methods spriteswitching etc.
/// </summary>
public class CurrentSelectCard{

    #region Variables
    public Animator Anim;
    public Button Butn;
    public SpriteWrapper SpriteWrp;
    public Sprite BackImage;
    #endregion

    /// <summary>
    /// Set values of the current card.
    /// CurrentSelectCard shoulds be created once(cardA cardB) then reuse them over and over.
    /// </summary>
    /// <param name="animator">The animator of the card</param>
    /// <param name="button">The button of the card(button.Gameobject) is used in SetNormalMode.cs</param>
    /// <param name="wrapper">The wrapped Sprite(holds concept)</param>
    /// <param name="backGround">The original back side of the card</param>
    public void SetCard(Animator animator, Button button, SpriteWrapper wrapper, Sprite backGround)
    {
        Anim = animator;
        Butn = button;
        SpriteWrp = wrapper;
        BackImage = backGround;
    
    }
    /// <summary>
    /// Reset the variables
    /// </summary>
    public void Reset()
    {
        //This method is not... "needed" but keeps things clean
        Anim = null;
        Butn = null;
        SpriteWrp = null;
        BackImage = null;
    }

    /// <summary>
    /// Fires Fade out Animation.(removal animation)
    /// </summary>
    public void FadeOut()
    {
        Anim.Play("FadeOut");
    }
    
    /// <summary>
    /// Fires TurnUp Animation.(reveal animation)
    /// </summary>
    public void TurnUp()
    {
        Anim.Play("TurnUp");

    }
    /// <summary>
    /// Fires Turn Down Animation(reset animation)
    /// </summary>
    public void TurnDown()
    {
        Anim.Play("TurnDown");
    }



    /// <summary>
    /// Used by animation events to change Button image mid animation
    /// </summary>
    public void SwitchSpriteUp()
    {
        Butn.image.sprite = SpriteWrp.SpriteObj;
    }
    /// <summary>
    /// Used by animation Events to change sprite back to the BackImage.
    /// </summary>
    public void SwitchSpriteDown()
    {
        Butn.image.sprite = BackImage;
    }
}
