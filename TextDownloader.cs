using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Networking;

using TMPro;

[RequireComponent(typeof(TextMeshPro))]
public class TextDownloader : MonoBehaviour
{
    [Header("GitHub")]
    public string username = "fchb1239";
    public string repository = "UnityTextDownloader";
    public string branch = "main";
    public string path = "TestTexts/MyText.txt";

    [Header("Other")]
    public string loadingText = "Loading...";

    private TextMeshPro text;

    private void Awake()
    {
        text = gameObject.GetComponent<TextMeshPro>();
        text.text = loadingText;
        StartCoroutine(LoadText());
    }

    private IEnumerator LoadText()
    {
        var request = GetTextRequest();
        Debug.Log("Sending request");
        yield return request.SendWebRequest();
        Debug.Log("Setting text");
        text.text = request.downloadHandler.text;
    }

    private UnityWebRequest GetTextRequest()
    {
        // Creates the request with the required data
        var request = new UnityWebRequest($"https://raw.githubusercontent.com/{username}/{repository}/{branch}/{path}", "GET");

        request.downloadHandler = new DownloadHandlerBuffer();

        return request;
    }
}

/*
MIT License

Copyright (c) 2022 fchb1239

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
