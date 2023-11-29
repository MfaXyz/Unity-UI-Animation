# Unity-UI-Animation
Simple Unity UI animation tool!

## Preview
![Project Preview](https://github.com/MfaXyz/Unity-UI-Animation/blob/main/Assets/Preview.png)

# XyzUITransition.cs 
*For moving UI elements attach XyzUITransition.cs to your object:*
## Description
XyzUITransition is a MonoBehaviour script in Unity that manages the transition of a UI element between two points. It provides options to auto-run the transition on Awake(), set the start position, and hide the object after the transition is done.

## Features
- Auto Run: If autoRun is set to true, the transition will start automatically on Awake().
- Delay To Start: You can set a delay before the transition starts using delayToStart.
- Speed Of Transition: The speed of the transition can be controlled using speedOfTransition.
- Set Start Position: If setStartPosition is true, the current position of the RectTransform will be set to firstPosition before the transition starts.
- Hide After Done: If hideAfterDone is true, the game object will be set to inactive after the transition is done.

## Usage
1. Attach the XyzUITransition script to the game object you want to animate.
2. In the inspector, set the firstPosition and secondPosition for the transition.
3. Set the speedOfTransition and delayToStart as per your requirements.
4. If you want the transition to start automatically on Awake(), set autoRun to true.
5. If you want the game object to start at firstPosition, set setStartPosition to true.
6. If you want the game object to be hidden after the transition, set hideAfterDone to true.

## Methods
- StartTransition(string newPos) Starts the transition manually.
- newPos: Pass an empty string for normal transition, 'D' to hide after completion.

## Note
Do not modify the worker variable as it is used internally to manage the transition.

# XyzImage&Sprite&TextFading.cs
*for changing color of UI elements attach XyzImageFading.cs or XyzSpriteFading.cs or XyzTextFading.cs to your object:*
## Description
XyzImageFading is a MonoBehaviour script in Unity that manages the fading of an image between two colors.

## Features
- Auto Run: If autoRun is set to true, the fading will start automatically on Awake().
- Delay To Start: You can set a delay before the fading starts using delayToStart.
- Speed Of Fading: The speed of the fading can be controlled using speedOfFading.
- Set Start Color: If setStartColor is true, the color of the Image will be set to xColor before the fading starts.
- Hide After Done: If hideAfterDone is true, the game object will be set to inactive after the fading is done.

## Usage
1. Attach the XyzImageFading script to the game object you want to animate.
2. In the inspector, set the xColor and yColor for the fading.
3. Set the speedOfFading and delayToStart as per your requirements.
4. If you want the fading to start automatically on Awake(), set autoRun to true.
5. If you want the game object to start at xColor, set setStartColor to true.
6. If you want the game object to be hidden after the fading, set hideAfterDone to true.

## Methods
- Awake(): Checks if autoRun is true. If so, it sets the start color and starts the fading after a delay.
- StartFading(string input): Starts the fading. The input is a string containing one or two HTML color codes separated by a comma. If there is one color code, it sets yColor to that color. If there are two color codes, it sets yColor to the first color and xColor to the second color.

## Note
Do not modify the worker variable as it is used internally to manage the fading.

## Contributing
1. Fork the repository and clone it locally.
2. Create a new branch for your feature: git checkout -b feature-name
3. Commit your changes: git commit -m 'Add new feature'
4. Push to the branch: git push origin feature-name
5. Submit a pull request.

## License
This project is licensed under the MIT License.

## Contact
For inquiries, please contact me at [MfaXyzOfficial@gmail.com].
