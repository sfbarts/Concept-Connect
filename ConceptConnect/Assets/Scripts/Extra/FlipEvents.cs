using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// WOLF_DEV
/// Made to RELAY Events from animations to SetUpNormalMode.cs
/// Only issue with this is If you make different modes, you need a different prefab for cards.
/// </summary>
public class FlipEvents : MonoBehaviour{

    //ref
    private SetUpNormalMode SetUpScript;
    public void Start()
    {
        //get ref to SetUpNormalMode.cs
        SetUpScript = FindObjectOfType<SetUpNormalMode>();
        //SetUpScript2 = FindObjectOfType<SetUpLearningMode>();
        //Check we have a reference.
        if (SetUpScript == null)
          throw new UnityException("SetupNormalMode.cs Must be added to FlipEvents of the card prefab");
        //if (SetUpScript2 == null)
          //  throw new UnityException("SetUpLearningMode.cs Must be added to FlipEvents of the card prefab");



    }

    #region EventRelays
    public void HalfTurnUpEvent()
    {
        SetUpScript.HalfTurnUpEvent(this.gameObject);
        //SetUpScript2.HalfTurnUpEvent(this.gameObject);
        //Debug.Log("Half TurnedUP Event");
    }
    public void HalfTurnDownEvent()
    {
        SetUpScript.HalfTurnDownEvent(this.gameObject);
        //SetUpScript2.HalfTurnDownEvent(this.gameObject);

        //Debug.Log("Half TurnedDOWN Event");
    }
    public void FinishedTurnDownEvent()
    {
        SetUpScript.FinishedTurnDownEvent(this.gameObject);
        //SetUpScript2.FinishedTurnDownEvent(this.gameObject);

        //Debug.Log("Finished Event");
    }
    public void FinishedTurnUpEvent()
    {
        SetUpScript.FinishedTurnUpEvent(this.gameObject);
        //SetUpScript2.FinishedTurnUpEvent(this.gameObject);

        //Debug.Log("Finished Event");
    }

    public void RemovedEventFinished()
    {
        SetUpScript.RemovedEventFinished(this.gameObject);
        //SetUpScript2.RemovedEventFinished(this.gameObject);

        //Debug.Log("Removed Finished");
    }
    #endregion
}
