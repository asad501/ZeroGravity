using UnityEngine.UI;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private Renderer lrenderer;
    private Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        lrenderer = this.GetComponent<Renderer>();
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (lrenderer.enabled)
        {
            int playerScore = PlayerPrefs.GetInt("score");
            PlayerPrefs.SetInt("score", playerScore + 1);
            playerScore = PlayerPrefs.GetInt("score");
            scoreText.text = playerScore + " OUT OF 23";
        }

        lrenderer.enabled = false;
        
    }
}
