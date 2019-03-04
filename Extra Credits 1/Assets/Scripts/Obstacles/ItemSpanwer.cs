using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpanwer : MonoBehaviour
{
    public Item[] items;
    public float delay;
    public bool stop;
    public Transform parent;

    int randItem;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        if (stop == true)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(delay);

        while (true)
        {
            randItem = Random.Range(0, this.items.Length);

            Instantiate(items[randItem], this.gameObject.transform.position, gameObject.transform.rotation, this.parent);

            yield return new WaitForSeconds(delay);
        }
    }
}