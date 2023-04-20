using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] LogicGround SpawnBrick;
    [SerializeField] GameObject floor;
    public int Stage;

    private Vector3 spawnPosition;
    // Start is called before the first frame update
    void Awake()    
    {
        spawnPosition = transform.position + Vector3.up*0.5f +Vector3.back *10f + Vector3.left *7f;
        for(int i=0; i < 10; i++)
        {
            for(int j=0; j < 10; j++)
            {
                LogicGround logicGround = Instantiate(SpawnBrick, spawnPosition + new Vector3(i*2f, 0f, j*2f), Quaternion.identity, floor.transform);
                //logicGround.GroundBrick.SetRandomColor();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
