using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackhole : MonoBehaviour
{
    public string unit_name;
    public GameObject spell;

    // Start is called before the first frame update
    void Start()
    {
        unit_name = "blackhole";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TouchedObject()
    {
        GameObject tempObj = Instantiate(spell, transform.position, Quaternion.identity);
        tempObj.transform.SetParent(this.transform);
        Destroy(this.gameObject,0.1f);
    }

}
