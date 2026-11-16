using GameHelper.Structs;
using UnityEditor;
using UnityEngine;
namespace GameHelper.Editor
{
[CustomPropertyDrawer(typeof(Delay))]
public class DelayPropertyDrawer : PropertyDrawer
{
 private static float[] delayValues=new float[2];
 static GUIContent[] clampedLabels= new GUIContent[2]
        {
            EditorGUIUtility.TrTextContent("Time"),
            EditorGUIUtility.TrTextContent("Max Time")
        };
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
          var labelField =  EditorGUI.BeginProperty(position,label,property);
          var values= DelayField(labelField,position,property.FindPropertyRelative("time").floatValue,property.FindPropertyRelative("maxTime").floatValue);
          property.FindPropertyRelative("time").floatValue=Mathf.Min(values[0],values[1]);
          property.FindPropertyRelative("maxTime").floatValue=values[1];
        EditorGUI.EndProperty();
   
    }
    public static float[] DelayField(GUIContent label,Rect position,float value,float max)
    {
         delayValues[0] =value;
        delayValues[1] = max;
        position.height = 18f;
        EditorGUI.BeginChangeCheck();
        EditorGUI.MultiFloatField(position,label, clampedLabels, delayValues);
        if (EditorGUI.EndChangeCheck())
        {
            value = delayValues[0];
            max = delayValues[1];
        }

        return delayValues;
    }
}
}