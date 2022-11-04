using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{

    [SerializedField] private string selectableTag = "Selectable";
    [SerializedField] private string startTag = "Start";
    [SerializedField] private string resetTag = "Reset";

    public GameManager gameManager;
    public SpawnManager spawnManager;

    public AudioSource click;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S)) {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f)) {
                if (hit.transform.CompareTag(selectableTag)) {
                    HitObject(hit.transform.gameObject);
                    if(gameManager.gameStarted) {
                        spawnManager.spawnTarget(1);
                    }
                    click.Play();
                    //PrintName(hit.transform.gameObject);
                }

                if (hit.transform.CompareTag(startTag)) {
                    //start the timer
                    hit.transform.gameObject.SetActive(false);
                    spawnManager.transform.gameObject.SetActive(true);
                    gameManager.startGame();
                    spawnManager.spawnTarget(1);
                    spawnManager.spawnTarget(1);
                }

                if (hit.transform.CompareTag(resetTag)) {
                    gameManager.ResetGame();
                }
            }
        }
    }

    private void PrintName(GameObject go) {
        print(go.name);
    }

    private void HitObject(GameObject gameObject) {
        Destroy(gameObject);
        gameManager.score++;
    }

    
}
