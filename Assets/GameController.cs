using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject moleContainer;
    public TextMesh infoText;
    public float spawnDuration = 1.5f;
    public float spawnDecrement = 0.1f;
    public float minimumSpawnDuration = 0.5f;
    public float gameTimer = 15f;
    public Player player;
    private float spawnTimer = 0f;
    private float resetTimer = 3f;

    private Mole[] moles;
	// Use this for initialization
	void Start () {
        moles = moleContainer.GetComponentsInChildren<Mole>();
	}
	
	// Update is called once per frame
	void Update () {
       

        gameTimer -= Time.deltaTime;
        if(gameTimer > 0f)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                moles[Random.Range(0, moles.Length)].Rise();
                spawnDuration -= spawnDecrement;
                if (spawnDuration <= minimumSpawnDuration)
                {
                    spawnDuration = minimumSpawnDuration;
                }
                spawnTimer = spawnDuration;
            }
            infoText.text = "Hit all the moles!\nTime: " + Mathf.Floor(gameTimer) + "\nScore: " + player.score;
        }
        else
        {
            infoText.text = "Game Over!\nScore: " + player.score;
            resetTimer -= Time.deltaTime;
            if(resetTimer <= 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
	}

}
