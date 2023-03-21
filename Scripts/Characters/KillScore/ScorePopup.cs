using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePopup : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);

        sprite.color = new Color(r, g, b, 1f);
    }
  
    // Update is called once per frame

    public void FadeScore()
    {

        Destroy(this.gameObject);

    }
}
