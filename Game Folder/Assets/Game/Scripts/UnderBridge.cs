using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class UnderBridge : MonoBehaviour
{
    [SerializeField] private Rigidbody player;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject checkForward;

    


    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<MeshRenderer>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
