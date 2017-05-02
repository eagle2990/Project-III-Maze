using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour 
{
    public GameObject poof;
    public AudioClip clip;
    //Create a reference to the CoinPoofPrefab
    public void OnCoinClicked() {
        AudioSource.PlayClipAtPoint(clip, transform.position, 1.0f);
        Object.Instantiate(poof, this.transform.position, Quaternion.Euler(-90, 0, 0));
        Destroy(gameObject);
    }

}
