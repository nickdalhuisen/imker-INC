using TMPro;
using UnityEngine;

public class ConvertHoney : MonoBehaviour
{
   

    public void ConvertTheHoney()
    {
        if (GameManager.instance.IsConverting == false)
        {
            GameManager.instance.IsConverting = true;
        }
        else GameManager.instance.IsConverting = false;
    }
}
 