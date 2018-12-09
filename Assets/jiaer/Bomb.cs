using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    public float existime;
    private void OnEnable()
    {
        StartCoroutine(ShowBomb());
    }

    IEnumerator ShowBomb()
    {
        yield return new WaitForSeconds(existime);
        gameObject.SetActive(false);
    }
}
