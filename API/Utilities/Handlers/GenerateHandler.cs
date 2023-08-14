namespace API.Utilities.Handlers;

public class GenerateHandler
{
    public static string Nik(string? nik = null)
    {
        if (nik is null)
        {
            return nik = "111111";
        }

        var newNik = Convert.ToInt32(nik) + 1;
        return newNik.ToString();
    }
}