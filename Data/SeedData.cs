public class SeedData
{
    public static void Init()
    {
        using (var context = new ApiContext())
        {
            //Ajout d'un User 
            User user1 = new User()
            {
                Name = "Jungkook",
                Last_Name = "Jeon",
                Age = 26,
                Profil_Picture = "lol.png",
            };

            context.SaveChanges();
        }
    }
}