using UnityEngine;

[CreateAssetMenu(fileName = "quiz_", menuName = "QuizQuestion")]
public class QuizQuestion : ScriptableObject
{
    public string Question;
    public string Anwser;
    public string[] BadAnwser;
}
