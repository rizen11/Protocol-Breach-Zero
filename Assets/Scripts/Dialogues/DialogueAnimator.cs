using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    public Animator dialAnim;
    public DialogueManager dm;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Hero>())
        {
            dialAnim.SetBool("startOpen", true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        dialAnim.SetBool("startOpen", false);
        dm.EndDialogue();
    }

}
