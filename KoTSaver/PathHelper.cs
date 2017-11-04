namespace KoTSaver
{
    public static class PathHelper
    {
        public static string DatabasesDirectory = "Databases\\";
        public static string MasksOfBasesDirectory = DatabasesDirectory + "MasksOfBases\\";

        public static string BaseDirectoryPath(string baseNum)
        {
            return DatabasesDirectory + BaseName(baseNum);
        }

        public static string BaseName(string baseNum)
        {
            return "BASE-" + baseNum;
        }

        public static string FileImageLayout(string baseNum, string layoutName)
        {
            return BaseDirectoryPath(baseNum) + "\\" + layoutName + ".jpg";
        }

        public static string MaskOfBaseFile(string name)
        {
            return MasksOfBasesDirectory + name + ".jpg";
        }

    }
}
