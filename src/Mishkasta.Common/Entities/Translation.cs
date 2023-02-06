namespace Mishkasta.Common.Entities;

public class Translation : Entity
{
    public int LocaleId { get; set; }

    public Locale Locale
    {
        get => (Locale)LocaleId;
        set => LocaleId = (int)value;
    }
}