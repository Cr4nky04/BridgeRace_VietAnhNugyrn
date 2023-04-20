using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class SeekBrickState : BotBaseState
{
    public Vector3 target;
    private bool isMoving;
    
    public override void EnterState(BotStateManager bot)
    {
        SeekRandomBrick(bot);
    }

    public override void UpdateState(BotStateManager bot)
    {
        Debug.Log(target);
        //Debug.Log("isEnough: " + isEnough);
        //if (!bot.isEnough)
        //{
        //    if (!bot.transform.GetComponent<Bot>().isMoving)
        //    {
        //        bot.transform.GetComponent<Bot>().Foods = Object.FindObjectsOfType<GroundBrick>().ToArray<GroundBrick>();
        //        GroundBrick[] groundBricks = bot.transform.GetComponent<Bot>().Foods;
        //        int countBrick = groundBricks.Length;
        //        int n = Random.Range(0, countBrick - 1);



        //        if (groundBricks[n].gameObject.transform.GetComponent<Renderer>().material.color == bot.transform.GetComponent<Renderer>().material.color)
        //        {
        //            bot.transform.GetComponent<Bot>().isMoving = true;
        //            Debug.Log(groundBricks[n].name);
        //            //Debug.Log(food[n].transform.position);
        //            float x = groundBricks[n].transform.position.x;
        //            float y = groundBricks[n].transform.position.y;
        //            float z = groundBricks[n].transform.position.z;
        //            target = new Vector3(x, y, z);
        //            //Vector3 direction = target - bot.transform.transform.position;
        //            //RaycastHit hit;    
        //        }
        //        if (bot.transform.GetComponent<Character>().EatBrick.Count <= 5)
        //        {
        //            bot.transform.GetComponent<NavMeshAgent>().SetDestination(target);

        //        }
        //    }
        //}

        
        if (bot.isEnough)
        {
            bot.SwitchState(bot.FinishState);
            //bot.transform.GetComponent<NavMeshAgent>().SetDestination(finishPoint.transform.position);
        }

        if (Vector3.Distance(bot.transform.position, target) < 1f)
        {

            SeekRandomBrick(bot);
        }
        //Debug.Log("Target: " + target);
        //Debug.Log("isMoving" + bot.transform.GetComponent<Bot>().isMoving);

        
    }

    public override void OnCollisonEnter(BotStateManager bot)
    {

    }

    private void SeekForBrick()
    {

        
    }

    public void SeekRandomBrick(BotStateManager bot)
    {
        //Debug.Log(bot.transform.GetComponent<Renderer>().material.color);
        List<GroundBrick> sameColorBricks = new();
        GroundBrick[] groundBricks = Object.FindObjectsOfType<GroundBrick>().ToArray<GroundBrick>();
        Debug.Log(groundBricks.Length);
        for (int i = 0; i < groundBricks.Length; i++)
        {
           
            if (groundBricks[i].gameObject.transform.GetComponent<GroundBrick>().Color == bot.transform.GetComponent<Character>().Color && groundBricks[i].GetComponentInParent<Floor>().Stage == bot.transform.GetComponent<Bot>().Stage)
            {
                sameColorBricks.Add(groundBricks[i]) ;
                Debug.Log("Mau cua bot" + groundBricks[i].gameObject.transform.GetComponent<Renderer>().material.color);
            }
        }
        Debug.Log(sameColorBricks.Count);
        int n = Random.Range(0, sameColorBricks.Count - 1);
        float x = sameColorBricks[n].transform.position.x;
        float y = sameColorBricks[n].transform.position.y + 0.5f;
        float z = sameColorBricks[n].transform.position.z;
        target = new Vector3(x, y, z);
        bot.transform.GetComponent<NavMeshAgent>().SetDestination(target);
    }
}
