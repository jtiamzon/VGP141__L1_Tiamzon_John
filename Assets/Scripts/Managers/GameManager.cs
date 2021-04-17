using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float m_JumpPower = 0.1f;
    static GameManager _instance = null;

    LinkedList<string> inventory = new LinkedList<string>();

    Rigidbody rb;
    AudioSource yahoo;

    public static GameManager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    public int jumpForce;
    public bool jump;
    public AudioClip yahooSound;

    public int maxHealth = 100;
    int _health;
    public int health
    {
        get { return _health; }
        set
        {
            if (_health > value)
            {
                _health = maxHealth;
            }
            _health = value;
            if (_health > maxHealth)
            {
                _health = maxHealth;
            }
            else if (_health < 0)
            {
                Debug.Log("YOU ARE DEAD");
            }
            Debug.Log("Current Health is: " + _health);

        }


    }

    // Start is called before the first frame update
    void Start()
    {
        jump = Input.GetKey("space");
        jump = false;
    }

    public void AddToList(string pItem)
    {
        inventory.AddLast(pItem);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (inventory.Count > 0)
            {
                Debug.Log(inventory.First.Value);
                if (inventory.First.Value == "Circle")
                {
                    // GameManager.instance.health = 100;  // somehow it doesn't set to the value for some reason
                    Debug.Log("Health becomes 100");
                    inventory.RemoveFirst();
                }
                else if (inventory.First.Value == "Square")
                {
                    yahoo = gameObject.AddComponent<AudioSource>();
                    yahoo.clip = yahooSound;
                    yahoo.loop = false;
                    yahoo.Play();
                    inventory.RemoveFirst();
                }
                else if (inventory.First.Value == "Tube")
                {
                    if (jump == false)
                    {
                        jump = true;
                        m_JumpPower = 12f;
                        inventory.RemoveFirst();
                    }
                }
                inventory.RemoveFirst();
            }
            else
            {
                inventory.Clear();
            }
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
