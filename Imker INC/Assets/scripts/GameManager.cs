using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public float Honey;
    public static GameManager instance;
    [SerializeField] TextMeshProUGUI HoneyCount;
    [SerializeField] float Money;
    [SerializeField] TextMeshProUGUI MoneyCount;
    public bool IsCoverting;


    [SerializeField] GameObject Row1;
    [SerializeField] GameObject WabenPrefab;
    [SerializeField] GameObject BeePrefab;
    public int BeeAmount;
    public int WabenAmount;
    Vector3 WabenSpawnPoint;
    [SerializeField] Transform BeeSpawn;
    bool WabenEven = false;
    [SerializeField] int currentRow;
    [SerializeField] int MaxRowAmount;
    int CurrentWabeninRow;
    bool CurrentRowEven = true;

    void Awake()
    {
        IsCoverting = false;
        currentRow = 1;
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        Row1 = GameObject.FindWithTag("Row1");


    }


    void Update()
    {
        HoneyCount.text = "Honey  " + Honey;
        MoneyCount.text = "$  " + Money;
        if (IsCoverting)
        {
            ConvertHoney();
        }
    }

    public void SpawnWaben()
    {
        if (WabenAmount >= MaxRowAmount * currentRow)
        {
            currentRow += 1;
            CurrentRowEven = currentRow % 2 == 0 ? true : false;
        }
        if (currentRow <= 1)
        {
            CurrentWabeninRow = WabenAmount;
        }
        else CurrentWabeninRow = WabenAmount - (MaxRowAmount * (currentRow - 1));

        float Xamount = 1.15f * CurrentWabeninRow;

        // dit deel fixen
        float Yamount = 0;
        Yamount = -1.34f * currentRow + (CurrentWabeninRow % 2 == 0 ? 0.67f : 0f);

        WabenSpawnPoint = new Vector3(Row1.transform.position.x + Xamount, Row1.transform.position.y + Yamount, 0);
        Instantiate(WabenPrefab, WabenSpawnPoint, Quaternion.identity);
        WabenAmount += 1;
        if (WabenEven == false)
        {
            WabenEven = true;
        }
        else WabenEven = false;
    }
    public void SpawnBee()
    {
       
        if (BeeAmount < WabenAmount)
        {
            Instantiate(BeePrefab, BeeSpawn.transform.position, Quaternion.identity);
            BeeAmount += 1;
        }
    }
    public void ConvertHoney()
    {

    }
}
