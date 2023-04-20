using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{
    private Vector3 target;
    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 direction;
    private float hDistance;
    private float vDistance;
    private bool isDragging;
    

    public override void Start()
    {
       base.Start();
    }
    public override void Update()
    {
       base.Update();
        //Move();
        //if(EatBrick.Count > 0)
        // {
        //     CheckBridge();
        // }

    }


    //private void Move()
    //{
    //    if(Input.GetMouseButtonDown(0))
    //    {
    //        startPos = Input.mousePosition;
    //        isDragging = true;
    //    }
    //    if(Input.GetMouseButtonUp(0))
    //    {
    //        isDragging = false;
    //    }
    //    if(isDragging)
    //    {
    //        endPos = Input.mousePosition;
    //        hDistance = endPos.x - startPos.x;
    //        vDistance = endPos.y - startPos.y;
    //        direction = new Vector3(hDistance, 0f, vDistance);
    //        target = transform.position + direction;
    //        player.velocity = direction * speed * Time.deltaTime;
    //        Debug.Log("Move");
    //        player.transform.LookAt(target);
    //    }
    //}

    
    //private void CheckBridge()
    //{
    //    RaycastHit hit;
    //    Debug.DrawRay(transform.position, Vector3.down * 100f, Color.red);
    //    if (Physics.Raycast(transform.position + Vector3.up * 0.5f, Vector3.down, out hit, 100f, bridgeLayer))
    //    {
    //        Debug.Log("Active");
    //        GameObject gameObject = hit.collider.gameObject;
    //        Instantiate(bridgeBrick, gameObject.transform.position + Vector3.up, Quaternion.identity);
    //        gameObject.SetActive(false);
    //        RemoveBrick();
    //    }

    //}

    

    
}

