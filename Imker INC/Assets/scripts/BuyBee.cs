using UnityEngine;

public class BuyBee : MonoBehaviour
{
   public void Buybee()
    {
        GameManager.instance.SpawnBee();
    }
}
