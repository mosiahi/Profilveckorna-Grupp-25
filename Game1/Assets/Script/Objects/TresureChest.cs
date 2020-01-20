using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TresureChest : Interactable
{
    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public SignalManager raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange || Input.GetKeyDown(KeyCode.K) && playerInRange)
        {
            if (!isOpen)
            {
                //Open The Chest
                OpenChest();
            }
            else
            {
                //Chest Is Alredy Open
                EmptyChest();
            }
        }
    }
    public void OpenChest()
    {
        //Dialog Window On
        dialogBox.SetActive(true);

        //Dialog Text = Contents Text
        dialogText.text = contents.itemDescription;

        //Add Contents To The Inventory
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;

        //Raise The Signal To The Player To Animate
        raiseItem.Raise();
        
        //Raise The Context Clue
        context.Raise();

        //Set The Chest To Opened
        isOpen = true;
        anim.SetBool("Opened",true);

    }
    public void EmptyChest()
    {
        //Dialog Off
        dialogBox.SetActive(false);

        //Raise The Signal To The Player To Stop Animating
        raiseItem.Raise();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = false;
        }

    }
}
