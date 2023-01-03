// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("hKbyY4atCHN9AeVoOk5KE8B2hVkeqxXgLi2lZpX12NWU0BNl0DG4xppfIxjgrIC9xtnqhgzq0EjnBxFTBQjZtO6mjBG0+8EgDLde70/hHXnheUs5zioNMPdsY1G/FsAM2amMKh9dZB8ntOi7JxYEEHCbus60cIWqmlCPgazz7uOCuzgzRphCMGLoL2me0fUi4ACdTRHU3fAyGR10zCebIufrwuRDhQ7GXgaf816uwnlIVYqqLJ4dPiwRGhU2mlSa6xEdHR0ZHB9D0KEZ7b1kyBElohLyS1AJlY3uW54dExwsnh0WHp4dHRy3U6oxWlprGbYtTEtuWJol2OBIdrMstZzf5/CiA1RVTn4PyMC846if0ipNHBo1cyAwm4Wd4LLJQR4fHRwd");
        private static int[] order = new int[] { 8,11,6,3,9,5,10,9,12,12,10,11,13,13,14 };
        private static int key = 28;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
