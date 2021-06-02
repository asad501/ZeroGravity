using UnityEngine.UI;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private new AudioSource audio;
    private AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        if (this.name.Contains("Spike"))
        {
            audio = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
            sound = Resources.Load<AudioClip>("Ouch");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.name.Contains("Spike"))
        {
            audio.clip = sound;
            audio.Play();
            GameObject player = collision.collider.gameObject;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.GetComponent<Rigidbody2D>().gravityScale = 0f;
            player.transform.position = new Vector3(-19.54f, 2.27f, 0);
            player.GetComponent<Rigidbody2D>().freezeRotation = false;
            PlayerPrefs.SetInt("score", 0);
            Fruit[] fruitsArray = GameObject.FindObjectsOfType<Fruit>();
            foreach (var fruit in fruitsArray)
            {
                fruit.gameObject.GetComponent<Renderer>().enabled = true;
            }

            Text Score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
            Score.text = "0 OUT OF 23";
        }

        if (collision.otherCollider.name.Contains("Trophy"))
        {
            sound = Resources.Load<AudioClip>("Game Won Final");
            audio.clip = sound;
            audio.Play();
        }
    }
}
