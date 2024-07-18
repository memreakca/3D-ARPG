using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropLoot : MonoBehaviour
{
    [SerializeField] private GroundItem lootPackage;

    [SerializeField] DropItem[] dropItems;


    public void SpawnLoot()
    {
        Vector3 lootPosition = transform.position + new Vector3(0, 1, 0);

        float randomNumber = Random.value;
        Debug.Log(" RANDOM VALUE " + randomNumber);
        foreach (DropItem item in dropItems)
        {
            if (randomNumber <= item.dropRate)
            {
                var obj = Instantiate(lootPackage.lootPackage, lootPosition, Quaternion.identity);
                obj.GetComponent<GroundItem>().item = item.dropItem;
                obj.GetComponent<GroundItem>().lootamount = item.amount;
                
            }
            
        }

    }
}

[System.Serializable]
public class DropItem
{
    public ItemObject dropItem;
    public int amount;
    [Range(0f, 1f)] public float dropRate;
}
