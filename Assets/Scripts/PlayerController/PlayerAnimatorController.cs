using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private PlayerMovement mov;
    private Animator anim;
    private SpriteRenderer spriteRend;
    private Rigidbody2D rd2D;

    [Header("Movement Tilt")]
    [SerializeField] private float maxTilt;
    [SerializeField] [Range(0, 1)] private float tiltSpeed;

    [Header("Particle FX")]
    [SerializeField] private GameObject jumpFX;
    [SerializeField] private GameObject landFX;
    private ParticleSystem _jumpParticle;
    private ParticleSystem _landParticle;

    //State
    public bool startedJumping {  private get; set; }
    public bool justLanded { private get; set; }
    public bool dashing { private get; set; }
    

    private void Start()
    {
        justLanded = true;
        mov = GetComponent<PlayerMovement>();
        spriteRend = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rd2D = GetComponent<Rigidbody2D>();
        _jumpParticle = jumpFX.GetComponent<ParticleSystem>();
        _landParticle = landFX.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        anim.SetFloat("AirSpeedY",rd2D.velocity.y);
    }

    private void LateUpdate()
    {
        #region Tilt
        float tiltProgress;

        int mult = -1;

        if (mov.IsSliding)
        {
            tiltProgress = 0.25f;
        }
        else
        {
            tiltProgress = Mathf.InverseLerp(-mov.Data.runMaxSpeed, mov.Data.runMaxSpeed, mov.RB.velocity.x);
            mult = (mov.IsFacingRight) ? 1 : -1;
        }
            
        float newRot = ((tiltProgress * maxTilt * 2) - maxTilt);
        float rot = Mathf.LerpAngle(spriteRend.transform.localRotation.eulerAngles.z * mult, newRot, tiltSpeed);
        transform.localRotation = Quaternion.Euler(0, 0, rot * mult);
        #endregion

        CheckAnimationState();

        ParticleSystem.MainModule jumpPSettings = _jumpParticle.main;
        //jumpPSettings.startColor = new ParticleSystem.MinMaxGradient(demoManager.SceneData.foregroundColor);
        ParticleSystem.MainModule landPSettings = _landParticle.main;
        //landPSettings.startColor = new ParticleSystem.MinMaxGradient(demoManager.SceneData.foregroundColor);
    }

    private void CheckAnimationState()
    {
        if (startedJumping)
        {
            anim.SetTrigger("Jump");
            anim.SetBool("Grounded",false);
            GameObject obj = Instantiate(jumpFX, transform.position - (Vector3.up * transform.localScale.y / 0.5f), Quaternion.Euler(-90, 0, 0));
            Destroy(obj, 1);
            startedJumping = false;
            return;
            
        }

        if (justLanded)
        {
            anim.SetBool("Grounded",true);
            GameObject obj = Instantiate(landFX, transform.position - (Vector3.up * transform.localScale.y / 0.5f), Quaternion.Euler(-90, 0, 0));
            Destroy(obj, 1);
            justLanded = false;
            Debug.Log("Land");
            return;
        }

        if (dashing)
        {
            anim.SetTrigger("Roll");
            dashing = false;
        }
        
        if (Mathf.Abs(mov.RB.velocity.x) > Mathf.Epsilon)
        {
            anim.SetInteger("AnimState", 1);
        }
        else
        {
            anim.SetInteger("AnimState", 0);
        }
    }
}
