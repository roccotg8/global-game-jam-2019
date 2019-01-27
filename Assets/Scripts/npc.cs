using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour
{
    GameObject[] itemsToFind;
    GameObject itemToFind;

    bool questActive, questComplete;

    GameObject monster = GameObject.FindGameObjectWithTag("monster");
    

    GameObject mapGenerator = GameObject.FindGameObjectWithTag("generator");
    

    // Start is called before the first frame update
    void Start()
    {
        questActive = questComplete = false;
    }

    void SpawnItem()
    {
        mapGeneration generator = mapGenerator.GetComponent<mapGeneration>();
        generator.GuaranteeOne(itemsToFind);
        itemToFind = GameObject.FindGameObjectWithTag("npcItem");
    }

    public void ActivateQuest()
    {
        questActive = true;
        SpawnItem();

        EnemyBehavior enemy = monster.GetComponent<EnemyBehavior>();
        enemy.IsHunting(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "npcItem" && questActive)
        {
            EnemyBehavior enemy = monster.GetComponent<EnemyBehavior>();

            enemy.IsHunting(false);
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
