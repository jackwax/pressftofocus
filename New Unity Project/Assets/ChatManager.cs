using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode]
public class ChatManager : MonoBehaviour {

    public GameObject prefab;
    public Transform content;
    public Transform scrollRect;

    public Sprite user1ChatBarSprite;
    public Sprite user2ChatBarSprite;

    public Color user1ImageColor;
    public Color user2ImageColor;

    public int fontSize;
    public Color textColor;

    private VerticalLayoutGroup verticalLayoutGroup;

    public UserChat userchat;



    //chat manager class to handle

	// Use this for initialization
	void Start () {
        StartCoroutine(RunMessages());
        
        
        //StartCoroutine(PostMessage(1, "wee ha"));
       // StartCoroutine(PostMessage(0, "Lol get it together u cuck"));
        //StartCoroutine(PostMessage(0, "Just go to class u faG"));







    }

    public IEnumerator RunMessages()
    {
        yield return StartCoroutine(MessageHandler("u weren't at school today lmao~0"));
        yield return StartCoroutine(MessageHandler(". . .~1"));
        yield return StartCoroutine(MessageHandler("Yeah man IDK I wasn't feeling good today~1"));
        yield return StartCoroutine(MessageHandler("Yeah man IDK I wasn't feeling good today~0"));

        //yield return StartCoroutine(MessageHandler("heheheheh~1"));

    }

    public IEnumerator MessageHandler(string message)
    {
        string[] split = message.Split('~');
        message = split[0];

        if (split[1] == "1")
        {
            yield return StartCoroutine(userchat.TypeMessage(message));

        }
        else if (split[1] == "0")
        {
            yield return StartCoroutine(NPCTypeMessage());
        }
        yield return StartCoroutine(PostMessage(int.Parse(split[1]), message));
    }


    public IEnumerator NPCTypeMessage()
    {

        yield return new WaitForSeconds(3f);
    }

    public IEnumerator PostMessage(int user, string message)
    {

        GameObject go = Instantiate(prefab, Vector2.zero, Quaternion.identity) as GameObject;
        go.transform.SetParent(content.transform, false);

        ChatObj cobj = go.GetComponent<ChatObj>();

        int fontSize = (int)(Screen.height * 0.0025f);

        cobj.parentText.fontSize = fontSize;
        cobj.childText.fontSize = fontSize;

        cobj.parentText.color = Color.white;

        cobj.parentText.text = message;

        yield return new WaitForEndOfFrame();

        float height = cobj.GetComponent<RectTransform>().rect.height;
        float width = cobj.GetComponent<RectTransform>().rect.width;


        //print("The height is: " + height);
        //print("The width is: " + width);

        cobj.chatbarImage.rectTransform.sizeDelta = new Vector2(width + 3 , height + 4);
        cobj.childText.rectTransform.sizeDelta = new Vector2(width, height);
        cobj.childText.text = message;
        cobj.parentText.text = "";

        if (user == 0)
        {
            cobj.chatbarImage.color = Color.gray;
            cobj.chatbarImage.sprite = user1ChatBarSprite;
            cobj.childText.color = Color.black;

            cobj.chatbarImage.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2((cobj.chatbarImage.transform.GetComponent<RectTransform>().anchoredPosition.x - cobj.transform.parent.GetComponent<RectTransform>().rect.width / 2) + (cobj.chatbarImage.transform.GetComponent<RectTransform>().rect.width / 2), cobj.chatbarImage.transform.GetComponent<RectTransform>().anchoredPosition.y);
        }

        else if (user == 1)
        {
            cobj.chatbarImage.color = Color.blue;
            cobj.childText.color = Color.white;
            cobj.chatbarImage.sprite = user2ChatBarSprite;
            cobj.chatbarImage.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2((cobj.chatbarImage.transform.GetComponent<RectTransform>().anchoredPosition.x + cobj.transform.parent.GetComponent<RectTransform>().rect.width / 2) - (cobj.chatbarImage.GetComponent<RectTransform>().rect.width / 2), cobj.chatbarImage.transform.GetComponent<RectTransform>().anchoredPosition.y);
        }
            scrollRect.GetComponent<ChatScrollRect>().verticalNormalizedPosition = 0f;


    }
	
	// Update is called once per frame
	void Update () {
        //Read Dialogue and find out where its going
        //if it goes to player, we call userChatMessage and call a coroutine on the
        // if player
        //      if inMessage == false && MessageDone
        //          inMessage = true
        //          StartCoroutine(TypeMessage nextDialogueLine)
        //      if UserChat.MessageDone == true && User Pressed Return
        //          create object from StartCoroutine PostMessage
        //          Reset User Chat

        //scrolling input
        if (Input.GetKey(KeyCode.UpArrow))
        {
            scrollRect.GetComponent<ChatScrollRect>().verticalNormalizedPosition += 0.05f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            scrollRect.GetComponent<ChatScrollRect>().verticalNormalizedPosition -= 0.05f;
        }

        
		
	}
}
