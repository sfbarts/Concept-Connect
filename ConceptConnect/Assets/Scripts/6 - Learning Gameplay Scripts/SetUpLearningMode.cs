using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUpLearningMode : MonoBehaviour {

    //sprite array to which I need to add the concepts
    private Sprite[] defaultSprites;

    //sprites being passed to the game
    //WOLF_DEV_MOD Changed to Wrapper.
    [SerializeField]
    private List<SpriteWrapper> gameSprites = new List<SpriteWrapper>();
    private List<Button> gameButtons = new List<Button>(); //list for buttons
    private List<Animator> gameButtonsAnimator = new List<Animator>();



    private bool firstGuess, secondGuess;
    private int firstGuessIndex, secondGuessIndex;
    private string firstGuessConcept, secondGuessConcept; //this will be used to check the cards


    //WOLFDEV
    private CurrentSelectCard CardA;
    private CurrentSelectCard CardB;
    public Sprite BackImage;
    public int SpritesPerSheet = 4;
    public float CompareDelaySeconds = 0.5f;
    //END WOLFDEV
    public GameObject ButtonsHolder;

    void Awake()
    {

        defaultSprites = Resources.LoadAll<Sprite>("Sprites"); //sprites being load
        //WOLFDEV
        //Create Cards to store selected card values.These will be reused each selection.
        CardA = new CurrentSelectCard();
        CardB = new CurrentSelectCard();


    }


    //function to prepare the sprites
    void PrepareGameSprites()
    {

        gameSprites.Clear();
        //WOLF_DEV_MOD Changed to Wrapper
        gameSprites = new List<SpriteWrapper>();

        //WOLFDEV
        //Sheets are randomly shuffled.(49)
        //Then i select the first (12) Sheets
        //Randomly takin (2) cards from each sheet
        //WARNING:: While Loop :: On randomly selecting cards on a sheet.        
        #region Select cards.
        //Number of Sprite sheets 
        int countSheets = (defaultSprites.Length / SpritesPerSheet);
        //Temp positional array
        int[] sheetIndices = new int[countSheets];
        for (int i = 0; i < countSheets; i++)
        {
            //Fill
            sheetIndices[i] = i;
        }
        for (int x = 0; x < countSheets; x++)
        {
            //Shuffle
            int pos = sheetIndices[x];
            int randomIndex = Random.Range(x, countSheets);
            sheetIndices[x] = sheetIndices[randomIndex];
            sheetIndices[randomIndex] = pos;
        }

        //set which sprites are part of the game
        for (int i = 0; i < 12; i++)
        {

            int sheetofSprites = (sheetIndices[i] * SpritesPerSheet);
            int cardOnSheet = Random.Range(0, 4);
            int actualPosInArray = sheetofSprites + cardOnSheet;

            SpriteWrapper temp = new SpriteWrapper(defaultSprites[actualPosInArray]);
            gameSprites.Add(temp);

            int secondCardOnSheet = Random.Range(0, 4);
            while (secondCardOnSheet == cardOnSheet)
                secondCardOnSheet = Random.Range(0, 4);

            actualPosInArray = sheetofSprites + secondCardOnSheet;

            SpriteWrapper temp2 = new SpriteWrapper(defaultSprites[actualPosInArray]);
            gameSprites.Add(temp2);


        }
        #endregion
        //END WOLFDEV
        //Rests color to white
        for (int i = 0; i < ButtonsHolder.transform.childCount; i++)
        {
            ButtonsHolder.transform.GetChild(i).gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        //Turns Cards back down
        for (int j = 0; j < ButtonsHolder.transform.childCount; j++)
        {
            CardA.SetCard(gameButtonsAnimator[j],
                  gameButtons[j],
                 gameSprites[j], BackImage);
            CardA.SwitchSpriteDown();

        }

        Shuffle(gameSprites);
        //Turnds cards up after shuffle
        TurnCardsOver();
    }

    void Shuffle(List<SpriteWrapper> list)
    {

        for (int i = 0; i < list.Count; i++)
        {

            SpriteWrapper temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }


    }


    //set level
    public void SetLevel()
    {

        PrepareGameSprites();

    }

    //set buttons and animators
    public void SetPuzzleButtonsAndAnimators(List<Button> gameButtons, List<Animator> gameButtonsAnimator)
    {

        this.gameButtons = gameButtons;
        this.gameButtonsAnimator = gameButtonsAnimator;

        AddListeners();
    }

    //------------ Level Game Manager ------------------
    public void PickACard()
    {     
            //Resets all the highlights to white
            for (int i = 0; i< ButtonsHolder.transform.childCount; i++)
            {
                ButtonsHolder.transform.GetChild(i).gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
            //this index is supposed to be changed to concept
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            //WOLFDEV 
            //Changed to CurrentSelectCard instead of Coroutines.
            CardA.SetCard(gameButtonsAnimator[firstGuessIndex],
                 gameButtons[firstGuessIndex],
                 gameSprites[firstGuessIndex], BackImage);
            //Looks for its matching pair
            for (int k = 0; k < ButtonsHolder.transform.childCount; k++)
            {
                CardB.SetCard(gameButtonsAnimator[k],
                     gameButtons[k],
                    gameSprites[k], BackImage);
            //Highlights the pair
                if (CardA.SpriteWrp.ConceptIndex == CardB.SpriteWrp.ConceptIndex)
                {
                    ButtonsHolder.transform.GetChild(k).gameObject.GetComponent<Image>().color = new Color32(0, 214, 252, 255);
                }

            }

        }
       

        

    

    void AddListeners()
    {

        foreach (Button btn in gameButtons)
        {
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() => PickACard());
        }
    }

    /// <summary>
    /// Events pass a Object, this gets the Card that has been selected(from an obj)
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>Current selected card</returns>
    private CurrentSelectCard GetCardFromObj(GameObject obj)
    {
        if (CardA.SpriteWrp != null)
        {
            if (CardA.Butn.gameObject == obj)
                return CardA;
        }

        if (CardB.SpriteWrp != null)
        {
            if (CardB.Butn.gameObject == obj)
                return CardB;
        }

        throw new UnityException("Card Roatating is not a Saved CardA or CardB, or both have been reset.");

    }


    #region Events
    /// <summary>
    /// Triggered when a card is half way thought the turn up animation(animation events/FlipEvents.cs relay)
    /// </summary>
    /// <param name="obj"></param>
    public void HalfTurnUpEvent(GameObject obj)
    {
        CurrentSelectCard card = GetCardFromObj(obj);
        card.SwitchSpriteUp();

        //Debug.Log("Half TurnedUP Event :" + card.SpriteWrp.ConceptIndex + " " + card.SpriteWrp.ConceptString);

    }
    /// <summary>
    /// Triggered when a card is half way thought the turn down animation(animation events/FlipEvents.cs relay)
    /// </summary>
    /// <param name="obj"></param>
    public void HalfTurnDownEvent(GameObject obj)
    {
        CurrentSelectCard card = GetCardFromObj(obj);
        card.SwitchSpriteDown();

        //Debug.Log("Half TurnedDOWN Event:" + card.SpriteWrp.ConceptIndex + " " + card.SpriteWrp.ConceptString);
    }
    /// <summary>
    /// Triggered when a card has finished turning down(from animations events/FlipEvents.cs relay).
    /// </summary>
    /// <param name="obj"></param>
    public void FinishedTurnDownEvent(GameObject obj)
    {
        CurrentSelectCard card = GetCardFromObj(obj);
        card.Reset();

        if (CardA.SpriteWrp == null && CardB.SpriteWrp == null)
        {
            firstGuess = false;
            secondGuess = false;

        }
        //Debug.Log("Finished Event");
    }
    /// <summary>
    /// Triggered when the card has finished turning up. (from animation events/FlipEvents.cs relay)
    /// </summary>
    /// <param name="obj"></param>
    public void FinishedTurnUpEvent(GameObject obj)
    {
        //Both cards
        if (secondGuess)
        {
            //The second card is the one calling this event
            //Else you could call compare while the second card is flipping.
            CurrentSelectCard card = GetCardFromObj(obj);
            if (card.Butn.gameObject == CardB.Butn.gameObject)
                StartCoroutine(CompareDelay());

        }
        //else
        // Debug.Log("Finished Event");
    }
    /// <summary>
    /// Triggered when a card has finished fading out/ removing (animation events/FlipEvents.cs relay)
    /// </summary>
    /// <param name="obj"></param>
    public void RemovedEventFinished(GameObject obj)
    {
        CurrentSelectCard card = GetCardFromObj(obj);
        card.Reset();

        if (CardA.SpriteWrp == null && CardB.SpriteWrp == null)
        {
            firstGuess = false;
            secondGuess = false;

        }
        //FADE FINISHED
        //Debug.Log("Removed Finished");
    }
    #endregion


    /// <summary>
    /// Creates a delay so cards don't start fading out when they flip.
    /// </summary>
    /// <returns></returns>
    IEnumerator CompareDelay()
    {
        //DEBUG
        //Debug.Log("Finished Event: CompareDelay Started");
        //END DEBUG

        yield return new WaitForSeconds(CompareDelaySeconds);

        if (CardA.SpriteWrp.ConceptIndex == CardB.SpriteWrp.ConceptIndex)
        {
            //They are the same Concept.
            //Score points and Remove?
            //DEBUG
            //Debug.Log("SAME CONCEPT");
            //END DEBUG
            CardA.FadeOut();
            CardB.FadeOut();
        }
        else
        {
            //DEBUG
            //Debug.Log("Turn Down From CompareDelay");
            //END DEBUG
            CardA.TurnDown();
            CardB.TurnDown();
        }

    }

//Turns all the sprites toface the front
public void TurnCardsOver()
    {
        for (int j = 0; j < ButtonsHolder.transform.childCount; j++)
        {
            CardA.SetCard(gameButtonsAnimator[j],
                  gameButtons[j],
                 gameSprites[j], BackImage);
                CardA.SwitchSpriteUp();

        }  
    }
    
}
