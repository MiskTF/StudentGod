using System;
using System.Collections;
using UnityEngine;
using Leap.Unity.Interaction;
public class StudentBehaviour : InteractionBehaviour {

    public GUIStyle style;
    public Transform player;
    public TextMesh timerMesh;

    bool prevGrabbed;
    Animator animator;

    bool wave = false;
    int wavingcount;
    int initialTimer = 40;
    int yellowThreshold = 20;
    int redThreshold = 10; 

    AudioSource[] audioSource;

    // Use this for initialization
    protected override void Start () {
        base.Start ();
        audioSource = GetComponents<AudioSource> ();
        player = GameObject.FindWithTag ("Player").transform;
        prevGrabbed = false;
        animator = GetComponent<Animator>();

        //Subscribe to events
        OnGraspBegin += SetTrigger;
        OnGraspEnd += SetGrabbed;

        timerMesh.text = initialTimer + "";
        timerMesh.color = Color.green;

        transform.LookAt (new Vector3 (player.position.x, transform.position.y, player.position.z));

        //Field values. Not made public yet.
        wavingcount = 3;


        StartCoroutine(Countdown());
        //StartCoroutine(Countwave());

    }

    // Update is called once per frame
    void Update () {
        
        timerMesh.transform.LookAt(new Vector3 (-player.position.x, -transform.position.y, -player.position.z));
        /*if (wave && !animator.GetCurrentAnimatorStateInfo (0).IsName ("wave2hands") && !animator.GetCurrentAnimatorStateInfo (0).IsName ("startWaving")) {
            animator.Play ("wave");
            wavingcount = 10;
            StartCoroutine (Countwave ());
        }*/

        if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("wave2hands") && !animator.GetCurrentAnimatorStateInfo (0).IsName ("startWaving")) {
            if (animator.GetCurrentAnimatorStateInfo (0).IsName ("walk")) {
                transform.Translate (Vector3.forward * Time.deltaTime * animator.GetFloat ("WalkSpeed"));
            }
            if (animator.GetCurrentAnimatorStateInfo (0).IsName ("run")) {
                transform.Translate (Vector3.forward * Time.deltaTime * animator.GetFloat ("RunSpeed"));
            }
            
            if (Vector3.Distance (transform.position, player.position) > 0.4f) {
                animator.Play ("walk");
            } else {
                animator.Play ("wave");
            }
        }

    }

    void SetTrigger() {
        //this.GetComponent<BoxCollider> ().isTrigger = true;

        animator.Play("startWaving");
        audioSource[0].Play();
        
    }

    void SetGrabbed() {
        prevGrabbed = true;
        animator.Play("jump-down");
        StartCoroutine (delayedCollider());
    }

    void OnCollisionEnter(Collision col) {
        if (col.collider.tag == "Ground" && prevGrabbed) {
            EventManager.FireOnStudentMissed(this.gameObject);
        }
    }

    public void RemoveStudent() {
        //TODO: Probably not needed.
        OnGraspEnd -= SetGrabbed;
        Destroy (gameObject);
    }

    IEnumerator Countdown() {
        int timer = initialTimer;
        while (timer > 0) {
            yield return new WaitForSeconds (1f);
            timer--;
            timerMesh.text = timer + "";
            if (timer <= yellowThreshold) {
                timerMesh.color = Color.yellow;
            }

            if (timer <= redThreshold) {
                timerMesh.color = Color.red;
            }
        }
        EventManager.FireOnStudentLate (this.gameObject);
    }

    IEnumerator Countwave()
    {
        wave = false;
        while (wavingcount > 0)
        {
            wavingcount--;
            yield return new WaitForSeconds(1f);
        }
        wave = true;

    }

    IEnumerator delayedCollider() {
        yield return new WaitForSeconds (0.1f);
        this.GetComponent<BoxCollider> ().isTrigger = false;
    }


}
