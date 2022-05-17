namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var serviceScope=app.ApplicationServices.CreateScope())
            {
                SeeData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void SeeData(AppDbContext? context)
        {
            if (!context.Contacts.Any())
            {
                Console.WriteLine("----> Seeding Data...");
                context.Contacts.AddRange(new Models.Contacts { Name = "Moein", Number = "09000000000"},
                new Models.Contacts { Name = "Docker", Number = "09111111111" },
                new Models.Contacts { Name = "Kubernetes", Number = "09222222222" }
                );
                context.SaveChanges();
            }            
        }
    }
}