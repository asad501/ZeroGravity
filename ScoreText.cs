using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private TextMesh scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = this.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
