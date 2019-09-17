using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiSlime : Ennemi
{

    GameObject player;
    public float speed = 5;
    Rigidbody rbd;
    AudioSource audioSource;
    public AudioMusic audioMusic;
    public GameObject particleSystemDeath;
    public GameObject ennemiSphere;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rbd = GetComponent<Rigidbody>();
        audioSource = GameObject.FindGameObjectWithTag("SoundPlayer").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        rbd.MovePosition(Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime));
    }

    public override void Die()
    {
        audioSource.PlayOneShot(audioMusic.soundToPlay);
        Instantiate(particleSystemDeath, gameObject.transform.position, Quaternion.identity);
        Instantiate(ennemiSphere, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
