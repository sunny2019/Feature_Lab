using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Crosstales.RTVoice;
using Crosstales.RTVoice.Model;

public class VoiceDemo : MonoBehaviour
{
    public InputField mTxtSpeakContent;
    public Button mBtnClick;
    private string mID;
    // Start is called before the first frame update
    void Start()
    {
        mBtnClick.onClick.AddListener(() => {
            //Speak(mTxtSpeakContent.text);
            mID = Speaker.Instance.Speak(mTxtSpeakContent.text,null, Speaker.Instance.Voices[1]);
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            mID = Speaker.Instance.Speak("测试语音功能是否正常！Test whether the voice function is normal",null, Speaker.Instance.Voices[1]);
            //Speaker.Instance.SpeakNative("测试语音功能是否正常！Test whether the voice function is normal", Speaker.Instance.Voices[0], 1, 1, 1);
            Debug.Log("开始ID:" + mID);
            Speaker.Instance.OnSpeakStart += SpeakStart;
            Speaker.Instance.OnSpeakComplete += SpeakComplete;
            //Speaker.Instance.Speak("why");//测试语音功能是否正常！
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Speaker.Instance.Silence(mID);
            mID = Speaker.Instance.Speak("我的目的是来测试id的", null, Speaker.Instance.Voices[1]);
            Debug.Log("开始ID:" + mID);
            Speaker.Instance.OnSpeakComplete += SpeakComplete;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Speaker.Instance.PauseOrUnPause();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Speaker.Instance.PauseOrUnPause();//
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Speaker.Instance.Silence(mID);//静默(介绍播放)
        }
    }
    private void SpeakStart(Crosstales.RTVoice.Model.Wrapper wrapper)
    {
        Debug.Log("开始播放ID:" + wrapper.Uid);
    }
    private void SpeakComplete(Crosstales.RTVoice.Model.Wrapper wrapper)
    {
        Debug.Log("完成ID:" + wrapper.Uid);
        if (wrapper.Uid.Equals(mID))
        {
            
        }
    }

    public void Speak(string _conetnt)
    {
        mID = Speaker.Instance.Speak(_conetnt, null, Speaker.Instance.Voices[1]);
    }
}
