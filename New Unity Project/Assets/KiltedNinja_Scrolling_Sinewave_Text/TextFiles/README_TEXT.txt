SCROLLING SINEWAVE TEXT

This will give you the functionality to have scrolling sinewave text in your projects.

You can choose to use a text asset (text file) or a string input for the scrolling text.

There is one prefab, and one script.

Prefab: ScrollingText
Script: ScrollyTextScript

Included is a demo scene containing 6 copies of the prefab with various settings.

Included as part of the demo scene is a simple "Button" object with a script called "ActivationButtonScript", this is not required for the function of the scrolling text, and is included just to demo the main scripts.


FUNCTIONS:
Everything is initialised in the Start function.  Text is parsed/converted, character objects are instantiated, etc.

There are two functions exposed;
	public void StartScrolling()
	public void StopScrolling()

Call the first one to start, and the second one to stop.


THE SETTINGS:

Text Asset:
---------------------------------------------
TEXTASSET; Choose/define a text file to use for your scrolling text.


Raw Text String:
---------------------------------------------
STRING; Alternative to a text file, enter a string of text.


Use Raw Text String:
---------------------------------------------
BOOLEAN; If a text-asset AND a string are present, this flag will let you choose which one will be used.


Characters To Spawn:
---------------------------------------------
INTEGER; Each letter of the text is spawned as an individual game object. This is the number of objects created.  Smaller text will require higher numbers of objects created.  See demo scene for examples.


Character Gen Speed:
---------------------------------------------
FLOAT; The rate at which new characters are generated from the string.


Text Scale:
---------------------------------------------
FLOAT; The scale of the font.


X Pos Speed:
---------------------------------------------
FLOAT; The speed at which each character will move across the screen.

Screen Bounds:
---------------------------------------------
FLOAT; The "width of the screen", that is: Where the characters start spawning on one side, and disappear on the opposite side.


Y Start Pos:
---------------------------------------------
FLOAT; The starting Y Position where the characters will spawn.


Use Bounce:
---------------------------------------------
BOOLEAN; Whether to make the sinewave bounce.


Use Cos:
---------------------------------------------
BOOLEAN; The sinewave uses the SIN function, this tells it to use the COS function instead. (For example, 2 streams of text with identical settings, but one is SIN and one is COS - gives a nice effect.)


Wave Height Individual:
---------------------------------------------
FLOAT; The Height of the Wave.


Wave Frequency Individual:
---------------------------------------------
FLOAT; The Frequency of the Wave.


Wave Divisor:
---------------------------------------------
FLOAT; "Divide" the wave by a certain amount, acts as a dampening effect.


Wave Turbulence:
---------------------------------------------
FLOAT; The amount of turbulence to apply to the wave.


Colour
---------------------------------------------
COLOR: The colour of the text.


BSCROLLING:
---------------------------------------------
BOOLEAN; publicly visible boolean to show whether the text is currently scrolling or not.  NOTE: This is intended to be a read-only property.

