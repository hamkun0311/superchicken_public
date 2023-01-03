using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fontmove : MonoBehaviour
{
    public float moveSpeed = 0.75f;
    TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        Invoke("destroyObject", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,moveSpeed * Time.deltaTime,0));
    }

    public void destroyObject()
    {
        Destroy(gameObject);
    }
}
