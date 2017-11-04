namespace KoTSaver
{
    public static class Data
    {
        public delegate void ChooseLayout(string baseNum, string layoutName);
        public static ChooseLayout EventHandlerChooseLayout;
    }
}
