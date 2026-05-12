using System.Collections;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public string[] lines;
    public float textspeed;
    private int index;

    void Start()
    {
        Text.text = string.Empty;
        DialogueStart();
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Text.text == lines[index])
            {
                NextDialogue();
            }
            else
            {
                StopAllCoroutines();
                Text.text = lines[index];
            }
        }
    }
    void DialogueStart()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            Text.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }

    void NextDialogue()
    {
        if (index < lines.Length - 1)
        {
            index++;
            Text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            index = 0;
        }
    }
}
