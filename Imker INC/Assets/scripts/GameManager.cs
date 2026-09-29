using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public float Honey;
    public static GameManager instance;
    [SerializeField] GameObject Row1;
    [SerializeField] GameObject WabenPrefab;
    int WabenAmount;
    Transform WabenSpawnPoint;
    
    void Awake()
    {

        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        Row1 = GameObject.FindWithTag("Row1");
    }

    
    void Update()
    {
        
    }

    public void SpawnWaben()
    {
        Debug.Log("skibidi");
        float Xamount = 1.6f * WabenAmount;
        WabenSpawnPoint.position = new Vector3(Row1.transform.position.x + Xamount, Row1.transform.position.y ,0);
        Instantiate(WabenPrefab, WabenSpawnPoint );
    }
}
