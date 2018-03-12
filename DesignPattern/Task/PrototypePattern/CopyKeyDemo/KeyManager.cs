namespace PrototypePattern.CopyKeyDemo
{
    class KeyManager
    {
        public static Key Copy(Key toCopyedKey, string needType, string needColor)
        {
            Key key = (Key)toCopyedKey.Clone();

            key.Setting(needType, needColor);

            return key;
        }
    }
}
