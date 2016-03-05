using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {
    public Transform target;
    public float smooth;
    // Use this for initialization
    void Start () {
	
	}
    
    // Update is called once per frame
    void Update () {
        //transform.LookAt(target);

        var lookPos = target.position - transform.position;
        lookPos.y = 0; var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * smooth);
    }
}
