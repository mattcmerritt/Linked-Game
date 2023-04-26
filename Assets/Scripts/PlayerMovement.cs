using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Rb;
    [SerializeField, Range(0f, 10f)] private float ThrusterSpeed;
    [SerializeField, Range(0f, 10f)] private int Lives; 
    [SerializeField] private ScoreManager ScoreManager;

    protected void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Rb.AddForce(input * ThrusterSpeed);
    }

    public void RemoveLife()
    {
        Lives--;
        ScoreManager.UpdateUIText();
        if(Lives <= 0)
        {
            ScoreManager.GameOver();
        }
    }

    public int GetLives()
    {
        return Lives;
    }
}
