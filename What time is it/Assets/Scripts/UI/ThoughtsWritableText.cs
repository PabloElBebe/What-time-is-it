public class ThoughtsWritableText : SoloWritableText
{
    private void Awake()
    {
        HelpSystems.OpenHelpHint += StartWriting;
    }
}
