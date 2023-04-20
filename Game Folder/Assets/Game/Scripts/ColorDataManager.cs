using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDataManager : MonoBehaviour
{
    public static ColorDataManager Instance;
    public ColorData ColorData;
    public List<int> listindex = new List<int> { 0, 1, 2, 3 };
    public List<int> pickedcolor = new List<int>();

    private void Awake()
    {
        Instance = this;
    }
}
