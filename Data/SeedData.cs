public class SeedData
{
    public static void Init()
    {
        using var context = new ApiContext();

        // Look for existing content
        if (context.Users.Any())
        {
            return;   // DB already filled
        }

        //Ajout d'un User 
        User user1 = new()
        {
            Name = "Jungkook",
            Last_Name = "Jeon",
            Age = 26,
            Profil_Picture = "lol.png",
        };

        context.Users.AddRange(user1);

        context.SaveChanges();
    }
}