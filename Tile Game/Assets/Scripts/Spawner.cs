using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public Object[] sprites;
    public float timer;
    private Vector2 size;
    private BoxCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        //prefabArray = new GameObject[3];
        timer = 0;
        sprites = Resources.LoadAll("Vehicles", typeof(Sprite));
        collider = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(collider.IsTouchingLayers(Physics2D.AllLayers) == false){
            timer -= 1;
        }
        if(timer <= 0){
            timer = Random.Range(100,200);
            GameObject car = Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
            car.transform.parent = this.transform; 
            car.GetComponent<SpriteRenderer>().sprite = (Sprite)sprites[Random.Range(0,sprites.Length)];
            car.AddComponent<BoxCollider2D>();
            car.GetComponent<BoxCollider2D>().isTrigger = true;
            size = car.GetComponent<BoxCollider2D>().size;
            car.GetComponent<BoxCollider2D>().size = new Vector2(size.x + (float)0.12, size.y);
        }
    }
}
