using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    [SerializeField] private float ForcaPulo;
    private float horizontal;
    private float Velocidade = 10f;
    private float TempVelocidade = 1.5f;
    private bool isRunning = false;
   
    private bool isFacingRight = true;

    [Header("Pulo")]
    private bool PodePular = true;
    private bool PuloDuplo = true;

    [Header("Dash")]
    [SerializeField] TrailRenderer TR;
    [SerializeField] private float CooldownDash = 1f;
    [SerializeField] private float DuracaoDash = 0.3f;
    [SerializeField] private float ForcaDash = 24f;
    private Vector2 DirecaoDash;
    private bool isDashing;
    private bool PodeDash;


    [Header("Wall Slide")]
    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;

    [Header("Wall Jump")]
    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(8f, 12f);

    [SerializeField] private Rigidbody2D Corpo;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;



    public void Start(){
        TR = GetComponent<TrailRenderer>();
    }

    
    private void Update()
    {

        if(isDashing){
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        
        if(isRunning){
            horizontal = Input.GetAxisRaw("Horizontal") * TempVelocidade;
        }


        if(IsGrounded())
        {
            PuloDuplo = true;
            PodePular = true;
            PodeDash = true;
            
        }
        else //Caso contrário, não se pode pular
        {        
            PodePular = false;  
        }


        if (Input.GetButtonDown("Jump")&& PodePular)
        {
            //Adiciona uma força para cima proporcional à ForçaPulo
            Corpo.velocity = new Vector2(Corpo.velocity.x, ForcaPulo);
            //Proíbe o jogador de pular
            PodePular = false;
        }

        if (Input.GetButtonDown("Jump") && !IsGrounded() && !isWallSliding)
        {

            if(PuloDuplo){
                //Adiciona uma força para cima proporcional à ForçaPulo
                Corpo.velocity = new Vector2(Corpo.velocity.x, ForcaPulo);
                //Proíbe o jogador de pular novamente no ar
                PuloDuplo = false;
            }
            
        }
        
         //Modifica a velocidade do jogador quando ele aperta e solta o botao de correr
        if (Input.GetButtonDown("Run")&& !isRunning){ 
            isRunning = true;
            
        }
        if (Input.GetButtonUp("Run")){
            isRunning = false;
            
        }


         if(Input.GetButtonDown("Dash")&&PodeDash){

            StartCoroutine(Dash());
         }

       

        
        WallSlide();
        WallJump();

        if (!isWallJumping)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        if (!isWallJumping)
        {
            Corpo.velocity = new Vector2(horizontal * Velocidade, Corpo.velocity.y);
        }
    }


    private IEnumerator Dash()
    {
        PodeDash = false;
        isDashing = true;
        float originalGravity = Corpo.gravityScale;
        Corpo.gravityScale = 0f;
        Corpo.velocity = new Vector2(transform.localScale.x * ForcaDash, 0f);
        TR.emitting = true;
        yield return new WaitForSeconds(DuracaoDash);
        TR.emitting = false;
        Corpo.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(CooldownDash);
        PodeDash = true;
    }
    //para o dash
    private IEnumerator ParaDash(){
        yield return new WaitForSeconds(DuracaoDash);
        TR.emitting = false;
        isDashing = false;
    }


    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if (IsWalled() && !IsGrounded() && horizontal != 0f)
        {
            isWallSliding = true;
            Corpo.velocity = new Vector2(Corpo.velocity.x, Mathf.Clamp(Corpo.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            Corpo.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if (transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public Boolean FacingRight(){
        return isFacingRight;
    }
}