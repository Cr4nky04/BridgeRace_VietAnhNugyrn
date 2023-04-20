using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] public List<GroundBrick> bricks;
    [SerializeField] private ColorData setColor;
    [SerializeField] protected float speed;
    [SerializeField] protected Rigidbody player;
    [SerializeField] protected GameObject spawnBrick;
    [SerializeField] protected GameObject spawnPosition;
    [SerializeField] protected LayerMask bridgeLayer;
    [SerializeField] protected GameObject bridgeBrick;
    [SerializeField] protected GameObject floor;
    [SerializeField] protected GameObject groundBrick;
    public BaseColor Color;
    public int n;
    public List<GameObject> EatBrick = new List<GameObject>();

    private Vector3 boundaryPoint;
    private Vector3 instantiatePosition;
    
    // Start is called before the first frame update
    public virtual void Start()
    {
        RandomColor();
        //n = Random.Range(0, 3);
        //Renderer renderer = GetComponent<Renderer>();
        //if (n == 0)
        //{
        //    renderer.material.color = Color.green;
        //}
        //if (n == 1)
        //{
        //    renderer.material.color = Color.blue;
        //}
        //if (n == 2)
        //{
        //    renderer.material.color = Color.red;
        //}
        //setColor.ChangeColor();
        //transform.GetComponent<Renderer>().material.color = setColor.Mats[setColor.colorindex].color;
    }

    public void RandomColor()
    {
        int colorIndex;
        do
        {
            colorIndex = Random.Range(0, 4);
        }
        while (!FindObjectOfType<ColorDataManager>().GetComponent<ColorDataManager>().listindex.Contains(colorIndex));
        
        //Debug.Log("dau cac mau" + colorIndex);
        FindObjectOfType<ColorDataManager>().GetComponent<ColorDataManager>().listindex.Remove(colorIndex);
        FindObjectOfType<ColorDataManager>().GetComponent<ColorDataManager>().pickedcolor.Add(colorIndex);
        Color = (BaseColor)colorIndex;
        transform.GetComponent<Renderer>().material = ColorDataManager.Instance.ColorData.GetRandomColor(colorIndex);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        spawnPosition.transform.localPosition = new Vector3(0,
                                                               spawnPosition.transform.localPosition.y, -0.85f);
        Build();
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spawn Brick")
        {
            LogicGround logicGround = other.GetComponent<LogicGround>();
            if (logicGround.MeshRenderer.material.color == gameObject.GetComponent<Renderer>().material.color)
            {
                logicGround.SelfRespawn();
                instantiatePosition = other.gameObject.transform.position;
                //Destroy(other.gameObject);
                //other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                Debug.Log("Instantiate");

                GameObject temp = Instantiate(spawnBrick, spawnPosition.transform.position, transform.rotation, transform);
                EatBrick.Add(temp);
                Material material = temp.GetComponent<Renderer>().material;
                material.color = transform.GetComponent<Renderer>().material.color;
                spawnPosition.transform.localPosition = new Vector3(0,
                                                                    spawnPosition.transform.localPosition.y, -0.85f);

                spawnPosition.transform.position += Vector3.up * 0.201f;
                spawnPosition.transform.localPosition = new Vector3(0,
                                                                    spawnPosition.transform.localPosition.y, -0.85f);

            }

            //Material material1 = transform.GetComponent<Renderer>().material;
            //Material material2 = other.transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
            //Color color1 = material1.color;
            //Color color2 = material2.color;
            //if (color1.Equals(color2))
            //{
            //    instantiatePosition = other.gameObject.transform.position;
            //    //Destroy(other.gameObject);
            //    other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            //    Debug.Log("Instantiate");

            //    GameObject temp = Instantiate(spawnBrick, spawnPosition.transform.position, transform.rotation, transform);
            //    EatBrick.Add(temp);
            //    Material material = temp.GetComponent<Renderer>().material;
            //    material.color = transform.GetComponent<Renderer>().material.color;
            //    spawnPosition.transform.localPosition = new Vector3(0,
            //                                                        spawnPosition.transform.localPosition.y, -0.85f);

            //    spawnPosition.transform.position += Vector3.up * 0.201f;
            //    spawnPosition.transform.localPosition = new Vector3(0,
            //                                                        spawnPosition.transform.localPosition.y, -0.85f);
            //    //Invoke(nameof(InstatiateBrick), 3f);
            //}
        }
    }

    public void RemoveBrick()
    {
        Destroy(EatBrick[EatBrick.Count - 1]);
        EatBrick[EatBrick.Count - 1].SetActive(false);
        EatBrick.Remove(EatBrick[EatBrick.Count - 1]);
        spawnPosition.transform.position += Vector3.down * 0.201f;
    }

    public void Build()
    {

        RaycastHit hit;
        //Debug.DrawRay(player.transform.position, Vector3.down, Color.red, 2f);
        if (Physics.Raycast(player.transform.position, Vector3.down, out hit, 2f, bridgeLayer))
        {

            if ((hit.collider.gameObject.GetComponent<MeshRenderer>().enabled == false))
            {
                Debug.Log("1");
                if (player.GetComponent<Character>().EatBrick.Count != 0)
                {

                    hit.collider.gameObject.GetComponent<MeshRenderer>().enabled = true;
                    hit.collider.gameObject.GetComponent<Renderer>().material.color = player.GetComponent<Renderer>().material.color;
                    RemoveBrick();
                    boundaryPoint = player.transform.position;

                }

                else
                {
                    if (player.transform.position.y > boundaryPoint.y)
                    {
                        player.transform.position = boundaryPoint;
                    }
                    if (player.transform.position.z > boundaryPoint.z)
                    {
                        player.transform.position = boundaryPoint;
                    }

                }
            }
            //Debug.Log(hit.collider.gameObject.GetComponent<Renderer>().material.color != player.gameObject.GetComponent<Renderer>().material.color);
            if ((hit.collider.gameObject.GetComponent<MeshRenderer>().enabled == true && hit.collider.gameObject.GetComponent<Renderer>().material.color != player.gameObject.GetComponent<Renderer>().material.color))
            {
                Debug.Log("2");
                if (player.GetComponent<Character>().EatBrick.Count != 0)
                {
                    hit.collider.gameObject.GetComponent<Renderer>().material.color = player.gameObject.GetComponent<Renderer>().material.color;

                    player.GetComponent<Character>().RemoveBrick();
                    boundaryPoint = player.transform.position;
                    //Debug.Log("same color");
                }


                else
                {
                    if (player.transform.position.y > boundaryPoint.y)
                    {
                        player.transform.position = boundaryPoint;
                    }
                    if (player.transform.position.z > boundaryPoint.z)
                    {
                        player.transform.position = boundaryPoint;
                    }

                }

            }



        }
    }

    protected void InstatiateBrick()
    {
        Instantiate(groundBrick, instantiatePosition, Quaternion.identity);
    }
}
