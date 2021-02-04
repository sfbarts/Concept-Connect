using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnEvents : MonoBehaviour {
    //ref
    private SetUpLearningMode SetUpScript;
    public void Start()
    {
        //get ref to SetUpNormalMode.cs
        SetUpScript = FindObjectOfType<SetUpLearningMode>();
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
        //Debug.Log("Half TurnedUP Event");
    }
    public void HalfTurnDownEvent()
    {
        SetUpScript.HalfTurnDownEvent(this.gameObject);

        //Debug.Log("Half TurnedDOWN Event");
    }
    public void FinishedTurnDownEvent()
    {
        SetUpScript.FinishedTurnDownEvent(this.gameObject);

        //Debug.Log("Finished Event");
    }
    public void FinishedTurnUpEvent()
    {
        SetUpScript.FinishedTurnUpEvent(this.gameObject);

        //Debug.Log("Finished Event");
    }

    public void RemovedEventFinished()
    {
        SetUpScript.RemovedEventFinished(this.gameObject);

        //Debug.Log("Removed Finished");
    }
    #endregion
}
