//
//Coded by KiltedNinja
//kiltedninja@yahoo.com
//
using UnityEngine;
using System.Collections;

public class ScrollyTextScript : MonoBehaviour {

	public TextAsset textAsset;
	public string RawTextString = "";
	public bool UseRawTextString = false;
	public int CharactersToSpawn = 0;
	public float CharacterGenSpeed = 0;
	public float TextScale = 0;
	public float xPosSpeed = 0;
	public float ScreenBounds = 0;
	public float YStartPos = 0;
	public bool UseBounce = false;
	public bool UseCos = false;
	public float WaveHeightIndividual = 0;
	public float WaveFrequencyIndividual = 0;
	public float WaveDivisor = 0;
	public float WaveTurbulence = 0;
	public Color Colour = new Color (0f, 0f, 0f);

	private GameObject CharacterTemplate;
	private GameObject[] Characters;
	private Transform[] ActiveTransforms;
	private bool[] ActiveCharacter;
	private float[] SineWaveIndices;

	private char[] TextChars;
	private int TextCharIndex;

	private bool bINITIALISED=false;
	public bool bSCROLLING=false;


	void Start () {
		bINITIALISED = false;
		bSCROLLING = false;
		StartCoroutine (Initialise ());
	}



	//---------------------------------------------
	// EXTERNAL CALLERS
	//---------------------------------------------
		public void StartScrolling(){
			StartCoroutine (ScrollRoutine ());
		}

		public void StopScrolling(){ 
			bSCROLLING = false;
			StopCoroutine (ScrollRoutine ());
		}
	//---------------------------------------------


	IEnumerator Initialise()
	{
		yield return new WaitForSeconds(0.00001f); 
		
	//Get The Character Template
		CharacterTemplate = gameObject.transform.Find ("CharacterTemplate").gameObject;
		
	//INIT the character object array
		Characters = new GameObject[CharactersToSpawn];
		ActiveCharacter = new bool[CharactersToSpawn];
		ActiveTransforms = new Transform[CharactersToSpawn];
		SineWaveIndices = new float[CharactersToSpawn];
		
	//Clone the template into the array
		for (int i=0; i < CharactersToSpawn; i++)
		{
			Characters[i]=(GameObject)Instantiate(CharacterTemplate);
			Characters[i].name = gameObject.name + "_Character_" + i.ToString();
			Characters[i].transform.parent=gameObject.transform;
			Characters[i].transform.localScale = new Vector3 (TextScale, TextScale, TextScale);
			Characters[i].GetComponent<TextMesh>().color=Colour;
			Characters[i].SetActive(false);
			ActiveCharacter[i]=false;
		}
		
	// Get the Text Asset, or the RAW STRING
		if (!UseRawTextString) {
			if (textAsset != null) {
				RawTextString = textAsset.text;
			}
		}
		
	// convert the text into a CHAR array
		TextChars = RawTextString.ToCharArray ();

		bINITIALISED = true;
	}


	//---------------------------------------------
	// MAIN SCROLL ROUTINE
	//---------------------------------------------
	IEnumerator ScrollRoutine()
	{
		if (!bINITIALISED) yield break;

		bSCROLLING = true;

		TextCharIndex = 0;
		while (bSCROLLING) {
			for (int i = 0; i < TextChars.Length; i++) {
				if(TextCharIndex==0)
				{
					SineWaveIndices[0]=SineWaveIndices[CharactersToSpawn-1];
				}
				else
				{
					SineWaveIndices[TextCharIndex]=SineWaveIndices[TextCharIndex-1];
				}
				SineWaveIndices[TextCharIndex]+=WaveTurbulence;

				//--------------------------------
				StartCoroutine(INIT_ScrollChar (TextCharIndex, TextChars [i]));
				//--------------------------------

				TextCharIndex++;
				if (TextCharIndex == CharactersToSpawn) {
					TextCharIndex = 0;

				}
				if (!bSCROLLING) {
					break;
				}
				yield return new WaitForSeconds (CharacterGenSpeed); 
			}

		}
		yield break;
	}

	//---------------------------------------------
	// Initialise the scrolling of one char
	//---------------------------------------------
	IEnumerator INIT_ScrollChar(int CharacterIndex, char sMessage)
	{
		// Init the character position, set the character string value, activate
		Characters[CharacterIndex].transform.localPosition=new Vector3(ScreenBounds,YStartPos,0);
		Characters[CharacterIndex].GetComponent<TextMesh>().text = sMessage.ToString();
		ActiveTransforms [CharacterIndex] = Characters [CharacterIndex].transform;
		Characters[CharacterIndex].SetActive (true);
		ActiveCharacter [CharacterIndex] = true;
		yield break;
	}


	//---------------------------------------------
	// FIXED UPDATE
	//	decrement X, get sinewave for Y
	//---------------------------------------------
	void FixedUpdate()
	{
		if (!bINITIALISED) return;
		
		for (int i=0; i < CharactersToSpawn; i++)
		{
			if(ActiveCharacter[i])
			{
				float localXpos = ActiveTransforms [i].transform.localPosition.x;
				float localYpos = ActiveTransforms [i].transform.localPosition.y;
				float localZpos = ActiveTransforms [i].transform.localPosition.z;
				localXpos = localXpos + xPosSpeed;
				localYpos=SinePosition(i, localYpos, WaveHeightIndividual, WaveFrequencyIndividual, UseBounce, UseCos);

				if(WaveDivisor==0){WaveDivisor=1;}

				localYpos=localYpos/WaveDivisor;
				Characters[i].transform.localPosition=new Vector3(localXpos,YStartPos+localYpos,localZpos);
				
				if(localXpos<(ScreenBounds*-1))
				{
					Characters[i].SetActive(false);
					ActiveCharacter[i]=false;
				}
			}
		}
	}


	// calculate sinewave
	private float SinePosition(int SineWaveIndex, float StartingYPos, float Height, float Frequency,bool Bounce, bool Cos)
	{
		float Offset = 0;

		SineWaveIndices [SineWaveIndex]+=WaveTurbulence;
		if(Cos){Offset = StartingYPos + ( Height*Mathf.Cos (Frequency*SineWaveIndices[SineWaveIndex]));}
		else{Offset = StartingYPos + (Height*Mathf.Sin (Frequency*SineWaveIndices[SineWaveIndex]));}
		
		if(Bounce){Offset = Mathf.Abs (Offset);}

		return Offset;
	}
//eos
}
