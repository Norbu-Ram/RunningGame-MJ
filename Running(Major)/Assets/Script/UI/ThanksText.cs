using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThanksText : MonoBehaviour
{
    Text detailsTxt;
    void Start()
    {
        detailsTxt = GetComponent<Text>();
        if (detailsTxt != null)
        {
            detailsTxt.text = " Finally you complete all of the levels of game .\n\n" +

                "Developers: \n" +
                "1.Norbu Sherpa \n " +
                "2.Santosh Karki \n" +
                "3.Sunity Pandit \n\n" 
                +
                "Music\n" +
                "1.pixabay.com \n" +
                "2.mixkit.com \n" +
                "3.opengamear \n" +
                "\n\n" 
                +
                "Game Art\n" +
                "1.Norbu Sherpa\n" +
                "2.Winter assetes\n" +
                "3.pikpng.com\n\n" 
                +
                "Concept/Tutorials\n" +
                "1.Blackthorprod\n" +
                "2.Brackey\n" +
                "3.Dani \n" +
                "Thank you for Playing Cube Thon and it will help if you provide any feedback "
                ;
        }
    }


}
