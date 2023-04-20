using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : Character
{
    // Start is called before the first frame update
    [SerializeField] private GameObject stairBrick;
    [SerializeField] private LayerMask stairLayer;
    [SerializeField] private GroundBrick[] foods;
    [SerializeField] private GameObject checkpoint;
    
    private Vector3 boundaryPoint;
    public bool isMoving;
    public int Stage = 1;


    public GroundBrick[] Foods { get => foods; set => foods = value; }

    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
       base.Update();
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if(other.tag=="CheckPoint")
        {
            Stage = 2;
        }
    }
}
