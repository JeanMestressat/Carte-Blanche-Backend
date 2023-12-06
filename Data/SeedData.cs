public class SeedData
{
    public static void Init()
    {
        using (var context = new ApiContext())
        {
            Ajout d'un User 
            User user1 = new User()
            {
                Name = "Jungkook",
                Last_Name = "Jeon",
                Age = 26,
                Profil_Picture = "lol.png"
            };
            // Todo Tache2 = new Todo()
            // {
            //     Task = "Faire à manger",
            //     Completed = true,
            //     Deadline = DateTime.Parse("2023-12-12"),
            // };
            // Todo Tache3 = new Todo()
            // {
            //     Task = "Faire le ménage",
            //     Completed = false,
            //     Deadline = DateTime.Parse("2024-02-23"),
            // };
            // context.Todos.AddRange(
            //     Tache1,
            //     Tache2,
            //     Tache3
            // );
            context.SaveChanges();
        }
    }
}