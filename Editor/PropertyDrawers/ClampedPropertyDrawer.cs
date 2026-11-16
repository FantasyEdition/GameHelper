using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using GameHelper.Structs;
namespace GameHelper.Editor
{
    [CustomPropertyDrawer(typeof(Clamped))]
public class ClampedPropertyDrawer : PropertyDrawer
{
    private static float[] clampedValues=new float[3];
    static GUIContent[] clampedLabels= new GUIContent[3]
        {
            EditorGUIUtility.TrTextContent("Value"),
            EditorGUIUtility.TrTextContent("Min"),
            EditorGUIUtility.TrTextContent("Max")
        };
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
          var labelField =  EditorGUI.BeginProperty(position,label,property);
          var values= ClampedField(labelField,position,property.FindPropertyRelative("value").floatValue,property.FindPropertyRelative("min").floatValue,property.FindPropertyRelative("max").floatValue);
          property.FindPropertyRelative("value").floatValue=Mathf.Clamp(values[0],values[1],values[2]);
          property.FindPropertyRelative("min").floatValue=Mathf.Min(values[1],values[2]);
          property.FindPropertyRelative("max").floatValue=values[2];
        EditorGUI.EndProperty();
   
    }
    public static float[] ClampedField(GUIContent label,Rect position,float value,float min, float max)
    {
         clampedValues[0] =value;
        clampedValues[1] = min;
        clampedValues[2] = max;
        position.height = 18f;
        EditorGUI.BeginChangeCheck();
        EditorGUI.MultiFloatField(position,label, clampedLabels, clampedValues);
        if (EditorGUI.EndChangeCheck())
        {
            value = clampedValues[0];
            min = clampedValues[1];
            max = clampedValues[2];
        }

        return clampedValues;
    }
}

}
