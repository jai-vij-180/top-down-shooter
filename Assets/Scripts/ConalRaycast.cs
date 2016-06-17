using UnityEngine;

[ExecuteInEditMode]
public class ConalRaycast : MonoBehaviour
{
    public float originOffset;
    public int searchSamplesDivisions = 10;
    public float searchDistance = 7.0f;
    public float searchWidth = 7.0f;
    public float alertDuration = 7.0f;

    private bool isAlert;
    private float spacing;

    void Update()
    {
        Search();
    }

    private void Search()
    {
        if (!isAlert)
        {
            // maths to figure out how far apart our raycasts should be at the end of the cone.
            spacing = (searchWidth * 2) / searchSamplesDivisions;

            // for each ray we want, figure out which direction it should go
            for (int i = 0; i <= searchSamplesDivisions; i++)
            {
                // The other raycasts below are just so we can visually see them, THIS is the actual raycasting
                RaycastHit2D hit = Physics2D.Raycast(
                    (Vector2)transform.position + ((Vector2)transform.up * originOffset)
                , -(Vector2)transform.up * searchDistance + ((-(Vector2)transform.right * searchWidth)) + ((Vector2)transform.right * (spacing * i))
                , searchDistance);

                if (hit && hit.transform.tag == "Player")
                {
                    // if we hit the player, see in the editor which ray that hit the player
                    Debug.DrawLine(
                        (Vector2)transform.position + ((Vector2)transform.up * originOffset)
                    , hit.point
                    , Color.green);

                    isAlert = true;

                    // ================================================
                    //This is where your code goes to shoot the player.
                    // ================================================

                    // This "break" will stop your for-loop iterating any further than it needs to if you have already seen the player.
                    break;
                }
                else
                {
                    // If we can't see the player, show us these rays
                    Debug.DrawRay(
                        (Vector2)transform.position + ((Vector2)transform.up * originOffset)
                    , -(Vector2)transform.up * searchDistance + ((-(Vector2)transform.right * searchWidth)) + ((Vector2)transform.right * (spacing * i))
                    , Color.red);
                }
            }
        }
    }
}
