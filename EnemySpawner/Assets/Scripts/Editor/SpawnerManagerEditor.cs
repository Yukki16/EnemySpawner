using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(SpawnerManager))]
public class SpawnerManagerEditor : Editor
{
	private SpawnerManager spawnerManager;

    private void OnEnable()
    {
		spawnerManager = (SpawnerManager)target;
	}
    void OnSceneGUI()
    {
        Handles.color = Color.yellow;
        
        //Handles.DrawWireCube(spawnerManager.transform.position, spawnerManager.size);
		ShowAndMovePoints();
    }

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		if (GUILayout.Button("Add a cube spawner"))
		{
			//spawnerManager.areaHandle.Add(new Vector3());
			spawnerManager.spawners.Add(SpawnerManager.TypeOfSpawner.Cubic, Vector3.zero);
			spawnerManager.areaSize.Add(new Vector3(1, 1, 1));
			// Button click event handler
			//Debug.Log("Button clicked!");
		}
	}


	void ShowAndMovePoints()
	{
		for (int i = 0; i < spawnerManager.spawners.Count; i++)
		{
			Vector3 currentPoint = spawnerManager.GetPoint(i);

			if (spawnerManager.spawners.ElementAt(i).Key == SpawnerManager.TypeOfSpawner.Cubic)
			{
				Handles.DrawWireCube(currentPoint, spawnerManager.areaSize[i]);
			}
			EditorGUI.BeginChangeCheck();
			Vector3 newPosition = Handles.PositionHandle(currentPoint, Quaternion.identity);
			if (EditorGUI.EndChangeCheck())
			{
				Undo.RecordObject(spawnerManager, "Moved spawner");
				EditorUtility.SetDirty(spawnerManager);
				spawnerManager.spawners[spawnerManager.spawners.ElementAt(i).Key] = newPosition;
			}
		}
	}

}
