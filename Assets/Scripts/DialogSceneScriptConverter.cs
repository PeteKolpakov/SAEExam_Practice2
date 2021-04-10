using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class DialogSceneScriptConverter
{
    const char LINE_FEED = (char)10;
    const char CARRIAGE_RETURN = (char)13;
    const char SPACE = (char)32;

    public static DialogSection[] Convert(string source)
    {
        if (source == null || source.Length == 0)
        {
            Debug.LogError("Trying to convert empty dialog script");
            return null;
        }

        LinkedList<DialogSection> sections = new LinkedList<DialogSection>();

        RemoveBoldMarkings(ref source);
        AppendEmptyLine(ref source);
        RemoveLineFeed(ref source);

        int currentSourceIndex = 0;

        if (!SaveChapterTitle(sections, source, ref currentSourceIndex)) return null;

        if (!SaveDialogSections(source, ref currentSourceIndex, sections)) return null;

        if (currentSourceIndex == source.Length)
        {
            Debug.Log("Dialog script Conversion succesful");
        }
        else
        {
            Debug.LogWarning("Finished converting, but not all characters where used: " + currentSourceIndex + " / " + source.Length);
        }

        return sections.ToArray();
    }


    // Scripts not ending with an empty line have the last section cutout
    private static bool SaveDialogSections(string source, ref int currentSourceIndex, LinkedList<DialogSection> sections)
    {
        int lineStart = currentSourceIndex;
        int lineEnd = source.IndexOf(CARRIAGE_RETURN, currentSourceIndex);
        int maxTries = 10000;
        int line = 0;

        DialogSection currentSection = new DialogSection();
        bool firstLineOfNewSentence = true;
        bool interlocutorIsChar1 = false;
        string oldInterlocutorName = "";

        //run until finished document or out of tries (infinite loop check)
        for (; lineEnd > 0 && line < maxTries; line++)
        {
            int lineLength = lineEnd - lineStart;

            //empty line -> start new dialog section, save old
            if (lineLength == 0)
            {
                //save last
                sections.AddLast(currentSection);
                //prep new
                currentSection = new DialogSection();
                firstLineOfNewSentence = true;
            }
            else
            {
                int spacesCount = CountStartingSpaces(source, lineStart);

                //Handle start of spoken sentence (Name of character)
                if (spacesCount > 8 && firstLineOfNewSentence)
                {
                    currentSection.InterlocutorName = CleanupLine(source, lineStart, lineEnd);

                    //change character location with different speaker
                    if (currentSection.InterlocutorName != oldInterlocutorName)
                        interlocutorIsChar1 = !interlocutorIsChar1;

                    currentSection.Interlocutor = interlocutorIsChar1 ? Interlocutor.Character1 : Interlocutor.Character2;
                    oldInterlocutorName = currentSection.InterlocutorName;
                }
                else
                {
                    currentSection.Text += CleanupLine(source, lineStart, lineEnd) + " ";
                }

                firstLineOfNewSentence = false;
            }

            //prep next line
            lineStart = lineEnd + 1;
            lineEnd = source.IndexOf(CARRIAGE_RETURN, lineStart);
        }

        Debug.Assert(line < maxTries, "Line Iterator reached max");

        //save the last processed character back into the referenced index
        currentSourceIndex = lineStart;
        return true;
    }

    private static void AppendEmptyLine(ref string source)
    {
        source += Environment.NewLine + Environment.NewLine;
    }

    private static string CleanupLine(string str, int startingIndex, int endIndex)
    {
        int count = CountStartingSpaces(str, startingIndex);
        int start = startingIndex + count;
        return str.Substring(start, endIndex - start);
    }

    private static int CountStartingSpaces(string str, int startingIndex)
    {
        int index = startingIndex;
        while (str[index] == SPACE)
        {
            index++;
        }
        return index - startingIndex;
    }

    private static void RemoveLineFeed(ref string source)
    {
        source = source.Replace((LINE_FEED).ToString(), "");
    }

    private static bool SaveChapterTitle(LinkedList<DialogSection> sections, string source, ref int currentSourceIndex)
    {
        int index = source.IndexOf(CARRIAGE_RETURN);

        if (index < 0)
        {
            Debug.LogWarning("No title found in scene script");
            return false;
        }

        currentSourceIndex = index + 1;
        DialogSection titleSection = new DialogSection();
        titleSection.Text = source.Substring(1, index - 2); //from 1 to max-2 to remove the chapter number, will fail with multidigit chapter numbers 
        sections.AddLast(titleSection);
        return true;
    }

    private static void RemoveBoldMarkings(ref string source)
    {
        source = source.Replace("<b>", "");
        source = source.Replace("</b>", "");
    }
}
