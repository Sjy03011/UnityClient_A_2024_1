using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Excharacter : MonoBehaviour
{ 
 
 public float speed = 5f;
 
 void Update()
 { 
    Move();
 } 

 protected virtual void Move()
 {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

 }

public void DestoryCharacter()
 {

    Destroy(gameObject);
 }
}