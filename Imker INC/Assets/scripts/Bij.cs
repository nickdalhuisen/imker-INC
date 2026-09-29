using Unity.VisualScripting;
using UnityEngine;

public class Bij : MonoBehaviour
{
    [SerializeField] public GameObject Target;
    [SerializeField] float BijSpeed;
    [SerializeField] GameObject ExtractPoint;
    public bool HoneyReady;
    [SerializeField] bool WabenFound;
    void Start()
    {
        HoneyReady = false;
        WabenFound = false;
    }

    private void Update()
    {
        if (HoneyReady == true)
        {
            Target = ExtractPoint;

        }
        
    }
    void FixedUpdate()
    {
        if(Target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.gameObject.transform.position ,BijSpeed );
        }

        if(Vector2.Distance(transform.position, Target.transform.position) < 0.1 && !HoneyReady )
        {
          var WabenScript = Target.GetComponent<Waben>();
           WabenScript.MakeHoney();
        }

        if(Vector2.Distance(transform.position, Target.transform.position) < 0.05 && HoneyReady == true)
        {
            GameManager.instance.Honey += 1;
            HoneyReady = false;
            Target = null;
            WabenFound = false;
        }
       
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Waben") && HoneyReady == false && WabenFound == false)
        {
           
            var ClosestWabenScript = other.gameObject.GetComponent<Waben>();
            if (ClosestWabenScript == null ) return;
            if (ClosestWabenScript.IsFree == true)
            {
                Target = other.gameObject;
                ClosestWabenScript.IsFree = false;
                WabenFound = true;
                ClosestWabenScript.Bij = gameObject;
            }
        }
        if(other.gameObject.CompareTag("Extract") && ExtractPoint == null )
        {
            ExtractPoint = other.gameObject;
        }
    }
   
}
