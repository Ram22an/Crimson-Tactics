using UnityEngine;
using UnityEditor;

public class ObstacleEditor : EditorWindow
{
    private ObstacleData obstacleData;

    [MenuItem("Tools/Obstacle Editor")]
    public static void ShowWindow()
    {
        GetWindow<ObstacleEditor>("Obstacle Editor");
    }

    private void OnGUI()
    {
        if (obstacleData == null)
        {
            obstacleData = (ObstacleData)EditorGUILayout.ObjectField("Obstacle Data", obstacleData, typeof(ObstacleData), false);
        }

        if (obstacleData != null)
        {
            EditorGUILayout.LabelField("Obstacle Grid", EditorStyles.boldLabel);

            for (int i = 0; i < 10; i++)
            {
                EditorGUILayout.BeginHorizontal();

                for (int j = 0; j < 10; j++)
                {
                    int index = i * 10 + j;
                    obstacleData.obstacles[index] = EditorGUILayout.Toggle(obstacleData.obstacles[index]);
                }

                EditorGUILayout.EndHorizontal();
            }

            if (GUILayout.Button("Save"))
            {
                EditorUtility.SetDirty(obstacleData);
                AssetDatabase.SaveAssets();
            }
        }
    }
}
