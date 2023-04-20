using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBrick : MonoBehaviour
{
    public BaseColor Color;
    private int n;

    void Start()
    {
        
        SetRandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRandomColor()
    {
        int colorIndex;
        colorIndex = Random.Range(0, 4);

        //Debug.Log("dau cac mau" + colorIndex);
        Color = (BaseColor)colorIndex;
        transform.GetComponent<Renderer>().material = ColorDataManager.Instance.ColorData.GetRandomColor(colorIndex);
    }
}
