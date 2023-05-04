using UnityEngine;
using System.Collections;

public class DestroyOnHit : MonoBehaviour 
{

	public GameObject explodedPrefab;

	public float explosionForce = 2.0f;
	public float explosionRadius = 5.0f;
	public float upForceMin = 0.0f;
	public float upForceMax = 0.5f;

	public bool autoDestroy = true;
	public float lifeTime = 5.0f;
	
	// Update is called once per frame

	/**
	 * This method was originally a OnCollisionEnter.  Changed
	 * to fit what we needed. 
	 */
	public void DestroyBarrel(Collider col)
	{	
		// TODO: Also need to check if the player is attacking
		// instantiate the exploding barrel
		GameObject go = (GameObject)Instantiate(
			explodedPrefab,
			gameObject.transform.position,
			gameObject.transform.rotation
		);

		// get the explosion component on the new object
		ExplodeBarrel explodeComp = go.GetComponent<ExplodeBarrel>();

		// set desired properties
		explodeComp.explosionForce = explosionForce;
		explodeComp.explosionRadius = explosionRadius;
		explodeComp.upForceMin = upForceMin;
		explodeComp.upForceMax = upForceMax;
		explodeComp.autoDestroy = autoDestroy;
		explodeComp.lifeTime = lifeTime;

		// Drop item if applicable
		if(this.GetComponent<BarrelItemHandler>().getWillDropItem())
        {
			gameObject.GetComponent<BarrelItemHandler>().dropItem();
        }

		// make the barrel explode
		explodeComp.Explode();

		// destroy the nice barrel
		Destroy(gameObject);
	}
}
