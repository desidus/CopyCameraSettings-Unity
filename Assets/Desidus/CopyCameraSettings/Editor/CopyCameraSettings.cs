/*
 *
 *                                /IIIIIII 
 *                       /SSSSSS |__  II_/ /DDDDDDD 
 *            /EEEEEEEE /SS__  SS   | II  | DD__  DD /UU   /UU
 *  /DDDDDDD | EE_____/| SS  \__/   | II  | DD  \ DD| UU  | UU  /SSSSSS 
 * | DD__  DD| EE      |  SSSSSS    | II  | DD  | DD| UU  | UU /SS__  SS
 * | DD  \ DD| EEEEE    \____  SS   | II  | DD  | DD| UU  | UU| SS  \__/
 * | DD  | DD| EE__/    /SS  \ SS /IIIIIII| DD  | DD| UU  | UU|  SSSSSS 
 * | DD  | DD| EE      |  SSSSSS/|_______/| DDDDDDD/| UU  | UU \____  SS
 * | DD  | DD| EEEEEEEE \______/          |_______/ |  UUUUUU/ /SS  \ SS
 * | DDDDDDD/|________/                              \______/ |  SSSSSS/
 * |_______/                                                   \______/ 
 * 
 *
 *
 * ============= CopyCameraSettings =============
 *
 * Plugin for Unity 2019.1 that allows to copy the settings of any 
 * Camera component to the Scene view Camera.
 *
 * Version:
 *   1.0
 *
 * Authors:
 *   Ettore Passaro <ettore3091@gmail.com>
 *	 Desidus <info@desidus.it>
 *
 */

using UnityEditor;
using UnityEngine;

namespace It.Desidus.EditorExtensions
{
	public class CopyCameraSettings : Editor
	{
		[MenuItem("CONTEXT/Camera/Copy Settings to Scene Camera", false, 1100)]
		public static void CopySettings()
		{
			Camera camera = Selection.activeTransform.GetComponent<Camera>();			
			SceneView scene = SceneView.lastActiveSceneView;
			if(scene == null)
			{
				Debug.LogError("LastActiveSceneView not found.");
				return;
			}
			
			Undo.RecordObject(scene, "Copy Camera Settings");
			scene.cameraSettings.fieldOfView = camera.fieldOfView;
			scene.cameraSettings.dynamicClip = false;
			scene.cameraSettings.nearClip = camera.nearClipPlane;
			scene.cameraSettings.farClip = camera.farClipPlane;
			scene.cameraSettings.occlusionCulling = camera.useOcclusionCulling;			
		}

		[MenuItem("CONTEXT/Camera/Copy FOV to Scene Camera", false, 1101)]
		public static void CopyFOV()
		{			
			Camera camera = Selection.activeTransform.GetComponent<Camera>();			
			SceneView scene = SceneView.lastActiveSceneView;
			if(scene == null)
			{
				Debug.LogError("LastActiveSceneView not found.");
				return;
			}

			Undo.RecordObject(scene, "Copy Camera FOV");
			scene.cameraSettings.fieldOfView = camera.fieldOfView;	
		}

		[MenuItem("CONTEXT/Camera/Align View to Camera", false, 1120)]
		public static void Align()
		{			
			Camera camera = Selection.activeTransform.GetComponent<Camera>();			
			SceneView scene = SceneView.lastActiveSceneView;
			if(scene == null)
			{
				Debug.LogError("LastActiveSceneView not found.");
				return;
			}

			Undo.RecordObject(scene, "Align View to Camera");
			scene.AlignViewToObject(camera.transform);	
			scene.cameraSettings.fieldOfView = camera.fieldOfView;	
		}
	}
}
