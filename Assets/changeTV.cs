using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeTV : MonoBehaviour
{

    public GameObject TV;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TV.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
