using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//SetUp and Level Game Manager
public class SetUpNormalMode : MonoBehaviour {

	[SerializeField]
	private Sprite[] defaultSprites; 

	[SerializeField]
	private LayoutNormalButtons layoutNormalButtons;

	[SerializeField]
	private List<SpriteWrapper> gameSprites = new List<SpriteWrapper>();

	private List<Button> gameButtons = new List<Button>();
	private List<Animator> gameButtonsAnimator = new List<Animator>();
   
    [SerializeField]
    private SelectNewMenu selectNewMenu;

    [SerializeField]
    private NormalModePanel normalModePanel;
   
	private bool firstGuess, secondGuess;
	private int firstGuessIndex, secondGuessIndex; 
	private string firstGuessConcept, secondGuessConcept; //this will be used to check the cards

    private CurrentSelectCard CardA;
    private CurrentSelectCard CardB;
    public Sprite BackImage;
    public int SpritesPerSheet = 4;
    public float CompareDelaySeconds = 0.5f;

    public GameObject ButtonsHolder;
    public int NumberOfSolvedPairs = 0;
	//--------------Game Set Up------------------------
	void Awake() {
      
        defaultSprites = Resources.LoadAll<Sprite> ("Sprites");
        CardA = new CurrentSelectCard();
        CardB = new CurrentSelectCard();

    }


    //function to prepare the sprites
    void PrepareGameSprites() {

        gameSprites.Clear ();
    
        gameSprites = new List<SpriteWrapper> ();
		      
        #region Select cards.
         
        int countSheets = (defaultSprites.Length / SpritesPerSheet);
      
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
        for (int i = 0; i < 12; i++) {

            int sheetofSprites = (sheetIndices[i] * SpritesPerSheet);
            int cardOnSheet = Random.Range(0, 4);
            int actualPosInArray = sheetofSprites + cardOnSheet;            
      
            SpriteWrapper temp = new SpriteWrapper(defaultSprites[actualPosInArray]);
            gameSprites.Add (temp);

            int secondCardOnSheet = Random.Range(0, 4);
            while(secondCardOnSheet == cardOnSheet)
                secondCardOnSheet = Random.Range(0, 4);

            actualPosInArray = sheetofSprites + secondCardOnSheet;

            SpriteWrapper temp2 = new SpriteWrapper(defaultSprites[actualPosInArray]);
            gameSprites.Add(temp2);


        }
        #endregion
       
        Shuffle (gameSprites);
        normalModePanel.counting = true;
        normalModePanel.t = 0;
        
     
       
    }

	void Shuffle(List<SpriteWrapper> list){

		for (int i = 0; i < list.Count; i++) {

			SpriteWrapper temp = list [i];
            int randomIndex = Random.Range(i, list.Count);
			list [i] = list [randomIndex];
			list [randomIndex] = temp;
		}


	}

   
	//set level
	public void SetLevel () {

		PrepareGameSprites ();
       
    }

	//set buttons and animators
	public void SetPuzzleButtonsAndAnimators (List<Button> gameButtons, List<Animator> gameButtonsAnimator){
        this.gameButtons = gameButtons;
		this.gameButtonsAnimator = gameButtonsAnimator;
        AddListeners ();
	}

	//------------ Level Game Manager ------------------

	//----------- Chris--------------
	public void PickACard(){
		if (!firstGuess) {

			firstGuess = true; 

			firstGuessIndex = int.Parse (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

			CardA.SetCard(gameButtonsAnimator[firstGuessIndex],
				gameButtons[firstGuessIndex],
				gameSprites[firstGuessIndex], BackImage);
			CardA.TurnUp();

		} else if (!secondGuess)
		{
			secondGuessIndex = int.Parse (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

			if (secondGuessIndex == firstGuessIndex)
				return;

			secondGuess = true;

			CardB.SetCard(gameButtonsAnimator[secondGuessIndex],
				gameButtons[secondGuessIndex],
				gameSprites[secondGuessIndex], BackImage);            
			CardB.TurnUp();
		}
	}

	//----------- Finish Chris------*/

	void AddListeners(){

		foreach (Button btn in gameButtons) {
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener (() => PickACard());
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
        
        if(CardA.SpriteWrp == null && CardB.SpriteWrp == null)
        {
            firstGuess = false;
            secondGuess = false;

        }
        //Debug.Log("Finished Event");
    }
    
    public void FinishedTurnUpEvent(GameObject obj) {
        //Both cards
        if (secondGuess)
        {
            //The second card is the one calling this event
            //Else you could call compare while the second card is flipping.
            CurrentSelectCard card = GetCardFromObj(obj);
            if(card.Butn.gameObject == CardB.Butn.gameObject)
                StartCoroutine(CompareDelay());
           
        }
        //else
           // Debug.Log("Finished Event");
    }
   
    public void RemovedEventFinished(GameObject obj) {
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



    IEnumerator CompareDelay() {
		
        yield return new WaitForSeconds(CompareDelaySeconds);

        if (CardA.SpriteWrp.ConceptIndex == CardB.SpriteWrp.ConceptIndex)
        {
            
            NumberOfSolvedPairs++;
           
			CardA.FadeOut();
			CardB.FadeOut();

            if (NumberOfSolvedPairs >= 12)
            {
                normalModePanel.GameFinished();
            }
        }
        else
        {
            CardA.TurnDown();
            CardB.TurnDown();
        }   

    }
		

	public List<Animator> ResetGameplay(){

		firstGuess = secondGuess = false;
		NumberOfSolvedPairs = 0;
		return gameButtonsAnimator;
	}

}
