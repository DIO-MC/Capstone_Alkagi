using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteStoneBeated : MonoBehaviour
{
    private int score_count;  //score when white stone beated
    // Start is called before the first frame update
    void Start()
    {
        score_count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y < 0)
        {
            score_count = score_count + 1;
        }
    }
}
