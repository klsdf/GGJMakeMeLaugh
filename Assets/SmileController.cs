using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmileController : MonoBehaviour
{
    public Sprite smile;
    public void Smile()
    {
        GetComponent<SpriteRenderer>().sprite = smile;
        transform.localScale = Vector3.one;
    }
}
