using System.Collections;
using System.Collections.Generic;
//using UnityEditor.PackageManager;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Asteroid asteroidPrefab;
    public int asteroidCount = 0;
    private int level = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (asteroidCount == 0){
            level++;
    
        }

        int numAsteroids = 4 + (2* level);
        for (int i =0; i < numAsteroids; i++){
            SpawnAsteroids();
        }


    }
    public void reduceCount(){
        asteroidCount-=1;
    }
    public int enemys(){
        return asteroidCount;
    }
    private void SpawnAsteroids(){
        float offset = Random.Range(0f,1f);
        Vector2 viewportSpawnPosition = Vector2.zero;

        int edge = Random.Range(0,4);

        if(edge == 0){
            viewportSpawnPosition = new Vector2(offset, 0);
        } else if (edge == 1){
            viewportSpawnPosition = new Vector2(offset, 1);
        } else if (edge == 2) {
            viewportSpawnPosition = new Vector2(0,offset);
        } else if (edge == 3){
            viewportSpawnPosition = new Vector2(1, offset);
        }
        
        Vector2 worldSpawnPosition = Camera.main.ViewportToWorldPoint(viewportSpawnPosition);
        Asteroid asteroid = Instantiate(asteroidPrefab, worldSpawnPosition, Quaternion.identity);
        asteroid.gameManager = this;

    }
    public void GameOver(){
        StartCoroutine(Restart());
        
    }

    private IEnumerator Restart() {
        Debug.Log("Game Over");

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        yield return null;
    }

}
