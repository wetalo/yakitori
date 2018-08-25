using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    private CharacterController myController;
    private Vector3 moveDirection = Vector3.zero;

    [Header("Gravity Variables")]
    [SerializeField]
    private float weight;
    [SerializeField]
    private float gravity;
    [SerializeField]
    private float horizontalGravity;
    [SerializeField]
    private float terminalDownVelocity;
    [SerializeField]
    private float terminalUpVelocity;

    [SerializeField]
    private Renderer chickenModel;

    [SerializeField]
    private GameEngine gameEngine;

    private ParticleSystem ps;
    public GameObject particleEmitter;

    [Space]
    [SerializeField]
    private float initialXVelocity;

    //movement
    private float myXVelocity = 0.0f;
    private float myZVelocity = 0.0f;
    private float myYVelocity = 0.0f;

    public bool frozen = true;
    public bool isDead = false;
    public bool wonGame = false;

    public AudioClip[] deathSounds;
    AudioSource source;


    private void Start()
    {
        myController = GetComponent<CharacterController>();
        myXVelocity = initialXVelocity;
        ps = particleEmitter.GetComponent<ParticleSystem>();
        source = GetComponent<AudioSource>();
    }

    void Update () {
        Gravity();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Freeze();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (frozen)
            {
                UnFreeze();
            } else if (wonGame)
            {
                gameEngine.LoadNextLevel();
            } else {
                gameEngine.ReloadLevel();
            }
        }
        
    }

    void LateUpdate()
    {
        //Set direction
        moveDirection = transform.TransformDirection(new Vector3(myXVelocity, myYVelocity, myZVelocity));


        //apply movement
        myController.Move(moveDirection * Time.deltaTime);

    }

    void Gravity()
    {
        if (myYVelocity > terminalDownVelocity && myYVelocity < terminalUpVelocity)
        {
            myYVelocity += gravity * Time.deltaTime;
        }
        else if (myYVelocity > terminalDownVelocity)
        {
            myYVelocity = terminalDownVelocity;
        } else if (myYVelocity < terminalUpVelocity)
        {
            myYVelocity = terminalUpVelocity;
        }

        if(myXVelocity > 0)
        {
            myXVelocity -= horizontalGravity * Time.deltaTime;
            if (myXVelocity < 0)
            {
                myXVelocity = 0;
            }
        } else if(myXVelocity < 0)
        {
            myXVelocity += horizontalGravity * Time.deltaTime;
            if (myXVelocity > 0)
            {
                myXVelocity = 0;
            }
        }
        
    }

    public void Push(float force, Fan.Direction direction)
    {
        switch (direction)
        {
            case Fan.Direction.Up:
                myYVelocity += force * Time.deltaTime;
                break;
            case Fan.Direction.Down:
                myYVelocity += -force * Time.deltaTime;
                break;
            case Fan.Direction.Right:
                myXVelocity += force * Time.deltaTime;
                break;
            case Fan.Direction.Left:
                myXVelocity += -force * Time.deltaTime;
                break;

        }
    }

    void UnFreeze()
    {
        frozen = false;
        gameEngine.Unfreeze();
    }

    void Freeze()
    {
        frozen = true;
        gameEngine.Freeze();
    }

    public void Die()
    {
        chickenModel.enabled = false;
        var emission = ps.emission;
        emission.enabled = true;
        ps.Play();

        isDead = true;
        gameEngine.ShowDeathScreen();

        AudioClip clip = deathSounds[Random.Range(0, deathSounds.Length)];
        source.PlayOneShot(clip);
    }

    public void Win()
    {
        gameEngine.ShowWinScreen();
        myXVelocity = 0f;
        myYVelocity = 0f;
        wonGame = true;
    }
}
