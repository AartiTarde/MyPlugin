//using Newtonsoft.Json;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

//

using static System.Net.WebRequestMethods;


namespace Plugin
{
   
    public class MyPluging : MonoBehaviour
    {

        // Start is called before the first frame update
        //public string uri = "https://catfact.ninja/fact";
        public string uri = "https://shop.tanhaji.in/api/get-promocodes";
        public string[] pages;
        public int page;
        public string jsonString = null;
        public string[] jsonStringArray;
        public TextMeshProUGUI text;
        public UnityWebRequest webRequest;
        void Start()
        {
            StartCoroutine(GetRequest());
         }
        public IEnumerator GetRequest()
        {
            using (webRequest = UnityWebRequest.Get(uri))
            {
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();

                  pages = uri.Split('/');
                 page = pages.Length - 1;

                switch (webRequest.result)
                {
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.DataProcessingError:
                        Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                        break;
                    case UnityWebRequest.Result.ProtocolError:
                        Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                        break;
                    case UnityWebRequest.Result.Success:
                        //Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);

                        //jsonString = webRequest.downloadHandler.text;
                        //jsonStringArray = new string[] { webRequest.downloadHandler.text };
                        //jsonString = webRequest.downloadHandler.text;
                        text.text=webRequest.downloadHandler.text;
                        /*GetData g = JsonConvert.DeserializeObject<GetData>(webRequest.downloadHandler.text);
                        Debug.Log("id" + g.code);
                        Debug.Log("id" + g.shivrai);*/

                       
                        break;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

    }
}