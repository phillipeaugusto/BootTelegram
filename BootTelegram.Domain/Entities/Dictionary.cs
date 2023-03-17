namespace BootTelegram.Domain.Entities;

public class DictionaryData: Entity
{
    public DictionaryData() { }

    public DictionaryData(string key, string value)
    {
        Key = key;
        Value = value;
    }

    public string Key { get; set; }
    public string Value { get; set; }
}