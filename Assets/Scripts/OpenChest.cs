using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    private Animator chestAnim;
    private Animator itemRise;
    private bool isOpen = false;
    private bool rising = false;
    private GameObject item;
    private GameObject itemLight;
    private float openTime;
    private Inventory inventory;
    private bool empty = false;
    void Start()
    {
        print(transform.parent.name);
        chestAnim = gameObject.GetComponentInParent<Animator>();
        item = transform.parent.GetChild(2).GetChild(0).gameObject;
        itemRise = item.GetComponent<Animator>();
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
    }

    void Update(){
        if(isOpen && Time.unscaledTime > openTime + 1f){
            itemRise.SetTrigger("chestIsOpen");
            isOpen = false;
            rising = true;
        }
        if(rising && Time.unscaledTime > openTime + 3f){
            item.SetActive(false);
        }
    }

    void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Player")){
            if(Input.GetKey(KeyCode.E) == true){
                chestAnim.SetBool("isOpen", true);
                isOpen = true;
                openTime = Time.unscaledTime;
                item.SetActive(true);
                if(item.transform.GetChild(0).gameObject.activeSelf == true && !empty){
                    inventory.pickUpPotion();
                    empty = true;
                }
                else if(item.transform.GetChild(0).gameObject.activeSelf == true && !empty){
                    inventory.numberOfFairies++;
                    empty = true;
                }
            }
        }
    }
}
