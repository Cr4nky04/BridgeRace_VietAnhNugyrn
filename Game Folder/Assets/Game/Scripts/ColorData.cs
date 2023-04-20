using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class ColorData : ScriptableObject
{

    public int colorindex;
    public Material[] Mats;

    private void OnEnable()
    {
        colorindex = Random.Range(0, 4);
    }
    public void ChangeColor()
    {
        colorindex++;
        if(colorindex == 4)
        {
            colorindex = 0;
        }

    }

    public Material GetRandomColor(int colorIndex)
    {
        return Mats[colorIndex];
    }
    
}

public enum BaseColor
{
    red = 0,
    yellow = 1,
    green = 2,
    blue = 3,
}
