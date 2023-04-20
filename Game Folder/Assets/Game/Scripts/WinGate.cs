using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WinGate : MonoBehaviour
{
    [SerializeField] float direction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OpenGate()
    {

        transform.Translate(0, 0, direction);
    }
    private void OnCollisionEnter(Collision collision)
    {
        OpenGate();
    }
}
