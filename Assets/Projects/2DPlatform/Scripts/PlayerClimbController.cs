using UnityEngine;

public class PlayerClimbController : MonoBehaviour
{
    public Ladder ladder;
    public float ladderProgress;

    private bool isVerticalPressed;
    public bool isClimbing;
    private float v;
    private float climbSpeed = 1;


    private void Update()
    {
        isVerticalPressed = Input.GetButtonDown("Vertical");
        if (isVerticalPressed && ladder)
        {
            Debug.Log("dgr");

            isClimbing = true;

            //rb.gravityScale = 0;
            //extraGravity = 0;

            ladderProgress = Mathf.InverseLerp(
                ladder.bottom.position.y
            , ladder.top.position.y
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


    private void SetPositionOnLadder()
    {
        transform.position = Vector3.Lerp(
            ladder.bottom.position
        , ladder.top.position
        , ladderProgress
        );
    }

    private void LadderMove()
    {
        v = Input.GetAxisRaw("Vertical");

        ladderProgress += v * climbSpeed * Time.deltaTime;
        SetPositionOnLadder();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Ladder")
        {
            ladder = collision.GetComponentInParent<Ladder>();
        }

        if (collision.transform == ladder.top)
        {
            Debug.Log("suceed");
            isClimbing = false;
        }

        if (collision.transform == ladder.bottom)
        {
            if (Input.GetButtonDown("Horizontal") && ladder)
            {
                Debug.Log("qehquwi");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ladder" && !isClimbing)
        {
            ladder = null;
        }
    }
}
