using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject jet;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;
    bool gameStarted = false;
    public GameObject tapText;
    public GameObject gameName;
    public TextMeshProUGUI scoreText;

    int score = 0;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)&& !gameStarted)
        {
            StartSpawning();
            gameStarted = true;
            tapText.SetActive(false);
            gameName.SetActive(false);
            Background.instance.moveBG = true;
           
        }
    }

    private void SpawnJets()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);

        Instantiate(jet, spawnPos, jet.transform.rotation);

        score++;
        scoreText.text = score.ToString();

    }
    void StartSpawning()
    {
        InvokeRepeating("SpawnJets", 1f, spawnRate);
    }
}
