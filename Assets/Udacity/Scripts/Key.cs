using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{
    public bool keyCollectedVariable;
    public GameObject lockedDoor;
    public GameObject KeyPoof;
    public AudioClip clip;

    void Start()
    {
        keyCollectedVariable = false;
    }

    void Update()
	{
		//Not required, but for fun why not try adding a Key Floating Animation here :)
	}

	public void OnKeyClicked()
	{
        AudioSource.PlayClipAtPoint(clip, transform.position, 1.0f);
        Object.Instantiate(KeyPoof, this.transform.position, Quaternion.Euler(-90, 0, 0));
        lockedDoor.GetComponent<Door>().Unlock();
        keyCollectedVariable = true;
        Destroy(gameObject);
    }

}
