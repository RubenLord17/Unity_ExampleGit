using UnityEngine;

public class obstaculo : MonoBehaviour
{
    public GameObject crate;
    public float maxspeed;
    public float minspeed;
    public float currentspeed;

    void Awake()
    {
        currentspeed = minspeed;
        generatecrate();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void generatecrate()
    {
        GameObject CrateIns = Instantiate(crate, transform.position, transform.rotation);

        CrateIns.GetComponent<mover>().controller = this;
    }
}