using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    bool hasPackage; // Initialises as false
    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
    SpriteRenderer spriteRenderer; //Create Variable to store Sprite Renderer Type Information in

    void Start() 
    {
       spriteRenderer = GetComponent<SpriteRenderer>(); // Store Sprite Renderer component in variable
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch!");
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !hasPackage) // or hasPackage == false
        { 
            Debug.Log("Package Picked Up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject,destroyDelay);
        }
        
        if (other.tag == "Customer" && hasPackage) // or hasPackage == true
        { 
            Debug.Log("Delivered Package");
            spriteRenderer.color = noPackageColor;
            hasPackage = false;
        }
    }

}
