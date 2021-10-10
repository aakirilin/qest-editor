namespace editor.Models.EnumHelpers
{
    public struct SelectorOption
    {
        public readonly string DiaplayName;
        public readonly string Value;

        public SelectorOption(string diaplayName, string value)
        {
            DiaplayName = diaplayName;
            Value = value;
        }
    }
}
