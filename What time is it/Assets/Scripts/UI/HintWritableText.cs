public class HintWritableText : SoloWritableText
{
    private void Awake()
    {
        HelpSystems.OpenHelpHint += StartWriting;
    }
}
