using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FinishState : BotBaseState
{
    public override void EnterState(BotStateManager bot)
    {
        Finish finish = Object.FindObjectOfType<Finish>();
        float x = finish.gameObject.transform.position.x;
        float y = finish.gameObject.transform.position.y+ 0.75f;
        float z = finish.gameObject.transform.position.z;
        Vector3 target = new Vector3((float)x, (float)y, (float)z);
        bot.transform.GetComponent<NavMeshAgent>().SetDestination(target);
        Debug.Log("Dich den la: " + finish.gameObject.transform.position);
    }

    public override void UpdateState(BotStateManager bot)
    {
        if(!bot.isEnough)
        {
            Debug.Log(2);
            bot.SwitchState(bot.SeekBrickState);
        }

    }

    public override void OnCollisonEnter(BotStateManager bot)
    {

    }
}
