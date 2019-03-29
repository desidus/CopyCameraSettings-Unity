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
