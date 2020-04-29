using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowSettings : MonoBehaviour
{

    private struct ResolotionOption
    {
        public int Width;
        public int Height;

        public ResolotionOption(int w, int h)
        {
            Width = w;
            Height = h;
        }

        public string GetText()
        {
            return Width + "x" + Height;
        }
    }

    public Dropdown ResolutionDropdown;
    public Toggle WindowedToggle;

    private ResolotionOption[] options =
    {
        new ResolotionOption(800,600),
        new ResolotionOption(1024,768),
        new ResolotionOption(1920,1080),
    };


    // Start is called before the first frame update
    void Start()
    {
        List<string> stringOpts = new List<string>();
        foreach (var opt in options)
        {
            stringOpts.Add(opt.GetText());
        }
        ResolutionDropdown.AddOptions(stringOpts);
    }

    public void SetResolution()
    {
        Screen.SetResolution(options[ResolutionDropdown.value].Width,
            options[ResolutionDropdown.value].Height,
            !WindowedToggle.isOn);
    }

}
