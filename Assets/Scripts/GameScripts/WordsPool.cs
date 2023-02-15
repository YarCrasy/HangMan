using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsPool : MonoBehaviour
{
    public static string[] words = new string[100];

    static string actualWord;
    static char[] actualWordCharArray;

    static string[] successecWords = new string[100];
    static int successedTimes = 0;

    private void Awake()
    {
        words = System.IO.File.ReadAllLines("Words.hmwords");
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = words[i].ToUpper();
        }
        SetActualWord();
    }

    public static void ResetSuccessed()
    {
        successecWords = new string[100];
        successedTimes = 0;
    }

    public static void AddSuccessed()
    {
        successecWords[successedTimes] = actualWord;
        successedTimes++;
    }

    static bool CheckWordIsDone()
    {
        bool find = false;

        for (int i = 0; !find && i < successedTimes; i++)
        {
            if (actualWord == successecWords[i]) find = true;
        }

        return find;
    }

    public static void SetActualWord()
    {
        actualWord = words[Random.Range(0, words.Length)];
        actualWordCharArray = actualWord.ToCharArray();
        if (CheckWordIsDone() == true) SetActualWord();
    }

    public static string GetActualWord()
    {
        return actualWord;
    }

    public static char[] GetActualCharArray()
    {
        return actualWordCharArray;
    }

    public static int GetSuccessedTimes()
    {
        return successedTimes;
    }
}
