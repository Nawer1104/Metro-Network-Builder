using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public GameObject explosionVfx;

    public GameObject wrongVfx;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Destroy()
    {
        StartCoroutine(SelfDestroyCoroutine());
    }

    public void Wrong()
    {
        GameObject explosion = Instantiate(wrongVfx, transform.position, transform.rotation);
        Destroy(explosion, 2f);
    }

    private IEnumerator SelfDestroyCoroutine()
    {
        anim.SetTrigger("Scale");

        yield return new WaitForSeconds(1);

        GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].enemies.Remove(this);

        GameObject explosion = Instantiate(explosionVfx, transform.position, transform.rotation);
        Destroy(explosion, .75f);
        Destroy(gameObject);
    }
}