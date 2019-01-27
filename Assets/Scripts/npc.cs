using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour
{
    GameObject[] itemsToFind;
    GameObject itemToFind;

    bool questActive, questComplete;
    
    // Start is called before the first frame update
    void Start()
    {
        questActive = questComplete = false;
    }

    void SpawnItem()
    {
        GameObject mapGenerator = GameObject.FindGameObjectWithTag("generator");
        mapGeneration generator = mapGenerator.GetComponent<mapGeneration>();
        generator.GuaranteeOne(itemsToFind);
        itemToFind = GameObject.FindGameObjectWithTag("npcItem");
    }

    public void ActivateQuest()
    {
        questActive = true;
        SpawnItem();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "npcItem" && questActive)
        {
            questComplete = true;
            questActive = false;
            Destroy(collision.gameObject);
            WaitForDeath();
            Destroy(this.gameObject);
        }
    }

    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(5);
    }
}
