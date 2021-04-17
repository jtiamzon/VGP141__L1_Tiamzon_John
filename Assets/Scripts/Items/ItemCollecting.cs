using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollecting : MonoBehaviour
{
    GameManager manager;

    public enum CollectibleItem
    {
        CIRCLE,
        SQUARE,
        TUBE
    };

    public CollectibleItem currentItem;
    
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")   // if collision of item is associated with player tag
        {
            switch (currentItem)
            {
                case CollectibleItem.CIRCLE:
                    Debug.Log("CirclePickedUp");
                    manager.AddToList("Circle");
                    Destroy(gameObject);
                    break;

                case CollectibleItem.SQUARE:
                    Debug.Log("SquarePickedUp");
                    manager.AddToList("Square");
                    Destroy(gameObject);
                    break;

                case CollectibleItem.TUBE:
                    Debug.Log("TubePickedUp");
                    manager.AddToList("Tube");
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
