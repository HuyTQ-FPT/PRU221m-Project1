using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
	private static Pool poolInstance;
	public static Pool Instance
	{
		get
		{
			if (poolInstance == null)
				poolInstance = FindObjectOfType<Pool>();

			return poolInstance;
		}
	}

	public GameObject[] PooledObjects;

	private Dictionary<string, GameObject> pooledObjects = new Dictionary<string, GameObject>();
	private Dictionary<string, Queue<GameObject>> pool = new Dictionary<string, Queue<GameObject>>();

	private void Start()
	{
		foreach (var item in PooledObjects)
		{
			RegisterObject(item);
		}
	}

	public void RegisterObject(GameObject prototype)
	{
		if (pooledObjects.ContainsKey(prototype.tag)) return;

		var singlePool = new Queue<GameObject>();
		pooledObjects.Add(prototype.tag, prototype);
		pool.Add(prototype.tag, singlePool);
	}

	public GameObject ActivateObject(string tag)
	{
		if (!pooledObjects.ContainsKey(tag))
			throw new KeyNotFoundException();

		var singlePool = pool[tag];

		if (singlePool.Count == 0)
		{
			var newItem = Instantiate(pooledObjects[tag], transform);
			return newItem;
		}

		var item = singlePool.Dequeue();

		return item;
	}

}
