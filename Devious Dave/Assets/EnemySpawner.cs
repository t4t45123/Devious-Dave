using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] float camHeight;
    [SerializeField] float camWidth;
    [SerializeField] float distanceFromEdge;
    [SerializeField] float timeBetweenSpawn;
    [SerializeField] float timeSinceLastSpawn;
    [SerializeField] float lastSpawnTime = 0;
    [SerializeField] float SpawnMargin;
    [SerializeField] bool Spawn;
    [SerializeField] float spawnArea;
    [SerializeField] int spawnAmount;
    [SerializeField] GameObject EnemyParent;
    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;
        camHeight = cam.orthographicSize * 2f;
        camWidth = cam.aspect * camHeight;
        

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn = Time.fixedTime - lastSpawnTime;
        if (Spawn) {
            if (timeBetweenSpawn < timeSinceLastSpawn) {
            SpawnEnemy(Enemy, spawnAmount);
        }
        }
        
    }
    void SpawnEnemy(GameObject Enemy, int amount) {
        lastSpawnTime = Time.fixedTime;
        Vector2 newPos = GetRandPos();
        for (int i = 0; i < amount; i++) {
            GameObject e = Instantiate(Enemy,GetRandArea(spawnArea, newPos),Quaternion.identity, EnemyParent.transform);
        }
        
    }
    Vector2 GetRandArea(float Distance, Vector2 Location) {
        Vector2 newPos = Location + new Vector2((Random.Range(Distance, Distance * -1)), Random.Range(Distance, Distance * -1));
        return newPos;
    }
    Vector2 GetRandPos() {
        float xPos = 0;
        float yPos = 0;
        bool Generated = false;
        Vector2 pos = new Vector2(0,0);
        Vector2 camAreaX = new Vector2 (Camera.main.transform.position.x - camWidth /2f, Camera.main.transform.position.x + camWidth /2f);
        Vector2 camAreaY = new Vector2(Camera.main.transform.position.y - camHeight /2f, Camera.main.transform.position.y + camHeight /2f);
        Vector2 SpawnAreaX = new Vector2 (camAreaX.x - distanceFromEdge,camAreaX.y + distanceFromEdge);
        Vector2 SpawnAreaY = new Vector2 (camAreaY.x - distanceFromEdge, camAreaY.y + distanceFromEdge); 
        while (!Generated) {
            xPos = Random.Range (SpawnAreaX.x,SpawnAreaX.y);
            yPos = Random.Range(SpawnAreaY.x, SpawnAreaY.y);
            if (!(xPos > camAreaX.x - SpawnMargin && xPos < camAreaX.y + SpawnMargin) || !(yPos > camAreaY.x - SpawnMargin && yPos < camAreaY.y + SpawnMargin)) {
                Generated = true;
                pos = new Vector2 (xPos,yPos);
                return pos;
            }
            if (Generated) {
                return pos;
            }
        }
        return(pos);
    }
}
