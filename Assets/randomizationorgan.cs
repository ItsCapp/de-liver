using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomizationorgan : MonoBehaviour
{
    public string organ;
    public string[] possibleorgans;

    public SpriteRenderer sr;

    public Sprite liver;
    public Sprite kidney;
    public Sprite heart;

    // Start is called before the first frame update
    void Start()
    {
        organ = possibleorgans[Random.Range(0, 2)];

        if (organ == "liver")
        {
            sr.sprite = liver;
        }
        else if (organ == "kidney")
        {
            sr.sprite = kidney;
        }
        else if (organ == "heart")
        {
            sr.sprite = heart;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
