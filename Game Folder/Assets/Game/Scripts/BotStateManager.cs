using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BotStateManager : MonoBehaviour
{
    BotBaseState currentState;
    public SeekBrickState SeekBrickState = new SeekBrickState();
    public BuildBridgeState BuildBridgeState = new BuildBridgeState();
    public FinishState FinishState = new FinishState();
    public WholeState WholeState = new WholeState();
    public bool isEnough;
    // Start is called before the first frame update
    void Start()
    {
        currentState = SeekBrickState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
        if (transform.GetComponent<Character>().EatBrick.Count > 5)
        {
            isEnough = true;
        }
        if (transform.GetComponent<Character>().EatBrick.Count == 0)
        {
            isEnough = false;
        }
        Debug.Log(currentState);
        Debug.Log(isEnough);
    }

    public void SwitchState(BotBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
