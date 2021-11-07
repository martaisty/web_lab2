using System.Collections.Generic;
using System.Linq;
using System.Threading;
using web_lab2.Models;

namespace web_lab2.DataInitializer
{
    public static class SampleData
    {
        private const string AdminRole = "Admin";
        private const string CustomerRole = "Customer";

        public static void Initialize(DatabaseContext ctx)
        {
            if (!ctx.Books.Any())
            {
                ctx.Books.AddRange(CreateBooks());
            }

            var roles = CreateRoles();
            if (!ctx.Roles.Any())
            {
                ctx.Roles.AddRange(roles);
            }

            if (!ctx.Users.Any())
            {
                ctx.Users.AddRange(CreateUsers(roles));
            }

            ctx.SaveChanges();
        }

        private static List<Book> CreateBooks()
        {
            return new[]
            {
                new Book
                {
                    Name = "Traitor of wood",
                    Description = "Hope springs from the knowledge that there is light even in the darkest of shadows."
                },
                new Book
                {
                    Name = "Captains And Invaders",
                    Description = "Judge your day by the seeds you plant for tomorrow"
                },
                new Book
                {
                    Name = "Enemies And Beasts",
                    Description =
                        "Desire is the seed from which all achievements are harvested. The starting point of all achievement is desire. (Napoleon Hill)"
                },
                new Book
                {
                    Name = "Failure Of The New Age",
                    Description =
                        "Be the sunshine on someone's rainy day. Try to be a rainbow in someone's cloud. (Maya Angelou)"
                },
                new Book
                {
                    Name = "Defenseless Against A Nuclear Winter",
                    Description =
                        "It's not the words you speak, but the way you say them that matters. People may hear your words, but they feel your attitude. (John C. Maxwell)"
                },
                new Book
                {
                    Name = "Failure Of Stardust",
                    Description =
                        "All it takes to change your world is to change the way you think. Change your thoughts and you change your world. (Norman Vincent Peale)"
                }
            }.ToList();
        }

        private static List<Role> CreateRoles()
        {
            return new[]
            {
                new Role {Name = AdminRole},
                new Role {Name = CustomerRole}
            }.ToList();
        }

        private static List<User> CreateUsers(List<Role> allRoles)
        {
            return new[]
            {
                new User
                {
                    Username = "Admin",
                    Password = "Admin",
                    Roles = allRoles
                },
                new User
                {
                    Username = "Makar",
                    Password = "Makar123",
                    Roles = allRoles.Where(r => r.Name.Equals(CustomerRole)).ToList()
                }
            }.ToList();
        }
    }
}