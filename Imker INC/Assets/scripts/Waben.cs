using UnityEngine;

public class Waben : MonoBehaviour
{
    public bool IsFree;
    [SerializeField] float HoneyTime;
    float Timer = 0;
   [SerializeField] public GameObject Bij;

    void Start()
    {
        IsFree = true;
    }

    
    void Update()
    {
        
    }
    public void MakeHoney()
    {
        IsFree = false;

        Timer += Time.deltaTime;
        if(Timer >= HoneyTime)
        {
            var BijScript = Bij.GetComponent<Bij>();
            BijScript.Target = null;
            BijScript.HoneyReady = true;
            IsFree = true;
            Timer = 0;
            Bij = null;
        }
    }
  
}
