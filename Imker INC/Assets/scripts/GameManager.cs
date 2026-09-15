using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public float Honey;
    public static GameManager instance;
    
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    
    void Update()
    {
        
    }
}
