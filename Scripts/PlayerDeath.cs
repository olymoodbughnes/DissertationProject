using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    private int lives;
    [SerializeField]
    EnemyBase enemyBase;
    
    [SerializeField] 
    private Text livesText;

    [SerializeField]
    PlayerSpawn Spawn;

    CoinCollector scoring;
    // Start is called before the first frame update
    private void Start()
    {
        print(Application.persistentDataPath);
        lives = System.Int32.Parse(File.ReadAllText(Application.persistentDataPath + "/Lives.txt"));
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        enemyBase = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyBase>();
        Spawn = GameObject.FindGameObjectWithTag("Start").GetComponent<PlayerSpawn>();
        scoring = gameObject.GetComponent<CoinCollector>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("FallingSpike") || collision.gameObject.CompareTag("SpinningSaw"))
        {
            elim();
        }
     
           
    }


    private void elim() {
        scoring.subScore();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void resetGame() {
        if (System.Int32.Parse(File.ReadAllText(Application.persistentDataPath + "/Lives.txt")) == 0)
        {
            
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
        else
        {

            int livesSaved = System.Int32.Parse(File.ReadAllText(Application.persistentDataPath + "/Lives.txt"));
            

            int UltimateLives = livesSaved - 1;
            string UltimateLivesToString = UltimateLives.ToString();
            File.WriteAllText(Application.persistentDataPath + "/Lives.txt", UltimateLivesToString);
            livesText.text = ": " + UltimateLives;
            rb.transform.position = Spawn.getPlayerSpawnPoint();
            anim.SetTrigger("Respawn");
            
        }
    
    }

    private void Respawn() {
        rb.bodyType = RigidbodyType2D.Dynamic;
        anim.SetTrigger("Idle");

    }

    public void addLife() {

        int livesSaved = System.Int32.Parse(File.ReadAllText(Application.persistentDataPath + "/Lives.txt"));


        int UltimateLives = livesSaved + 1;
        string UltimateLivesToString = UltimateLives.ToString();
        File.WriteAllText(Application.persistentDataPath + "/Lives.txt", UltimateLivesToString);


    }

    public int getLives()
    {

        return System.Int32.Parse(File.ReadAllText(Application.persistentDataPath + "/Lives.txt"));

    }
}
