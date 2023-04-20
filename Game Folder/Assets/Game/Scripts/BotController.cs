using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class BotController : MonoBehaviour
{
    [SerializeField] private GameObject finishPoint;


    public NavMeshAgent agent;

    private bool isEnough = false;
    private Vector3 target;
    private float x, y, z;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("isEnough: " + isEnough);
        if(!isEnough)
        {
            SeekForBrick();
        }
        
        if (agent.GetComponent<Character>().EatBrick.Count == 0)
        {
            isEnough = false;
        }
        if (isEnough)
        {
            agent.SetDestination(finishPoint.transform.position);
        }
        
        if (Vector3.Distance(agent.transform.position, target) < 1f)
        {
            
            agent.GetComponent<Bot>().isMoving = false;
        }
        Debug.Log("Target: " + target);
        Debug.Log("isMoving"+agent.GetComponent<Bot>().isMoving);
        
    }

    private void SeekForBrick()
    {

        if(!agent.GetComponent<Bot>().isMoving)
        {
            GroundBrick[] food = FindObjectsOfType<GroundBrick>().ToArray();
            int countBrick = food.Length;
            int n = Random.Range(0, countBrick - 1);
            


            if (food[n].gameObject.transform.GetComponent<Renderer>().material.color == agent.transform.GetComponent<Renderer>().material.color)
            {
                agent.GetComponent<Bot>().isMoving = true;
                //Debug.Log(food[n].transform.position);
                x = food[n].transform.position.x;
                y = food[n].transform.position.y;
                z = food[n].transform.position.z;
                target = new Vector3(x, y, z);
                //Vector3 direction = target - agent.transform.position;
                //RaycastHit hit;    
            }
            if (agent.GetComponent<Character>().EatBrick.Count <= 5)
            {
                agent.SetDestination(target);

            }
            if (agent.GetComponent<Character>().EatBrick.Count > 5)
            {
                isEnough = true;
            }

        }
    }
}
