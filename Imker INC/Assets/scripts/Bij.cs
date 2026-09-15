using Unity.VisualScripting;
using UnityEngine;

public class Bij : MonoBehaviour
{
    [SerializeField] public GameObject Target;
    [SerializeField] float BijSpeed;
    public bool HoneyReady;
    void Start()
    {
        HoneyReady = false;
    }

   
    void FixedUpdate()
    {
        if(Target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.gameObject.transform.position ,BijSpeed );
        }
        if(transform.position == Target.gameObject.transform.position)
        {
          var WabenScript = Target.GetComponent<Waben>();
            WabenScript.MakeHoney();
        }
        if(transform.position == Target.gameObject.transform.position && HoneyReady)
        {
            GameManager.instance.Honey += 1;
            HoneyReady = false;
            Target = null;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Waben") && HoneyReady == false)
        {
           
            var ClosestWabenScript = other.gameObject.GetComponent<Waben>();
            if (ClosestWabenScript == null ) return;
            if (ClosestWabenScript.IsFree == true)
            {
                Target = other.gameObject;
            }
        }
        if(other.gameObject.CompareTag("Extract") && HoneyReady)
        {
            Target = other.gameObject;
        }
    }
   
}
