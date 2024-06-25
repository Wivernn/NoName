using TMPro;
using UnityEngine;

public class P2DPickup : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI txtScore;

    //---------------------------------------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PickUp")
        {
            Destroy(collision.gameObject);
            score++;

            txtScore.text = score.ToString();
        }
    }
}
