using UnityEngine;

public class PlayerClimbController : MonoBehaviour
{
    public Ladder ladder;
    public float ladderProgress;
    private bool isVerticalPressed;
    public bool isClimbing;
    private float v;
    private float climbSpeed = 1;

    //---------------------------------------------------------------------------------------------

    private void Update()
    {
        isVerticalPressed = Input.GetButtonDown("Vertical");
        if (isVerticalPressed && ladder)
        {
            //detect to see if player is currently climbing
            Debug.Log("Player on ladder");

            isClimbing = true;

            //rb.gravityScale = 0;
            //extraGravity = 0;
            //gravity scale and extra gravity were removed due to causing issues with player movement

            ladderProgress = Mathf.InverseLerp(
                ladder.bottomOn.position.y
            , ladder.topOn.position.y
            , transform.position.y
            );

            SetPositionOnLadder();
        }

        if (isClimbing)
        {

            LadderMove();

            return; //if code is run succesfully, don't execute code below this line within the void
        }

    }

    //---------------------------------------------------------------------------------------------

    private void SetPositionOnLadder()
    {
        transform.position = Vector3.Lerp( //lerp uses two points to record a linear progression (position is recorded between 0-1)
            ladder.bottomOn.position
        , ladder.topOn.position
        , ladderProgress
        );
    }

    private void LadderMove()
    {
        v = Input.GetAxisRaw("Vertical");

        ladderProgress += v * climbSpeed * Time.deltaTime;
        SetPositionOnLadder();
        //determins where on the ladder the player is currently
    }

    //---------------------------------------------------------------------------------------------

    private void OnTriggerStay2D(Collider2D collision)
    {
     //detect whether or not player is colliding with ladder enter or exit points
        if (collision.tag == "Ladder/On")
        {
            ladder = collision.GetComponentInParent<Ladder>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Ladder/Off")
        {
            Debug.Log("Player can enter/exit ladder"); 
            isClimbing = false;
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ladder/On" && !isClimbing)
        {
            ladder = null;
        }
    }
}
