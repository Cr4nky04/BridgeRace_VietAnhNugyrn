using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class LogicGround : MonoBehaviour
{
    public GroundBrick GroundBrick;
    public Collider Col;
    public MeshRenderer MeshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Respawn();
    }
    //void Respawn()
    //{
    //    if (transform.GetChild(0).gameObject.active == false)
    //    {
    //        //Debug.Log("SetActive");
    //        Invoke(nameof(Active), 3f);
    //        int n = Random.Range(0, 3);
           
    //        if (n == 0)
    //        {
    //            transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = UnityEngine.Color.green;
    //        }
    //        if (n == 1)
    //        {
    //            transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = UnityEngine.Color.blue;
    //        }
    //        if (n == 2)
    //        {
    //            transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = UnityEngine.Color.red;
    //        }
    //    }
    //}

    void Active()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void SelfRespawn()
    {
        StartCoroutine(DelayRespawn());
    }

    private IEnumerator DelayRespawn()
    {
        Col.enabled = false;
        MeshRenderer.enabled = false;
        yield return new WaitForSeconds(3f);
        Col.enabled = true;
        MeshRenderer.enabled = true;
    }
}
