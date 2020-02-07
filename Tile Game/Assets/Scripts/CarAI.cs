using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAI : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 velocity;
    public Rigidbody2D r;
    private Spawner parent;
    void Start()
    {
        parent = transform.parent.GetComponent<Spawner>();
        velocity = new Vector2(1, 0);
    }
    void OnBecameInvisible(){
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Car"){
            collision.gameObject.GetComponent<CarAI>().velocity = new Vector2(0,0);
        }
    }
    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag == "Car"){
            StartCoroutine(start());
        }
    }
    IEnumerator start(){
            //Debug.Log("Started Coroutine at timestamp : " + Time.time);
            yield return new WaitForSeconds(1);
            velocity = new Vector2(1,0);
    }
    // Update is called once per frame
    void Update()
    {
        r.MovePosition(r.position + velocity * Time.fixedDeltaTime);
    }
}
