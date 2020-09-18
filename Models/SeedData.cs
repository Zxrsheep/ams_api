using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using mvc_test.Data;
using System;
using System.Linq;

namespace mvc_test.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new mvc_testContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<mvc_testContext>>()))
            {
                // Look for any movies.
                if (context.user.Any())
                {
                    return;   // DB has been seeded
                }

                context.user.AddRange(
                    new user
                    {
                        ID = "00001",
                        password = "AQAAAAEAACcQAAAAEHEssUxpzhTyfpII//d9cPJ/DE4XLQKwrL//Fue0rzW2uXI8bl2Zz6KegKwEe9LU4Q==",  //1212
                        type = "student"
                    },

                    new user
                    {
                        ID = "00002",
                        password = "AQAAAAEAACcQAAAAEHEssUxpzhTyfpII//d9cPJ/DE4XLQKwrL//Fue0rzW2uXI8bl2Zz6KegKwEe9LU4Q==",  //1212
                        type = "teacher"
                    }

                 
                );
                context.SaveChanges();
            }
        }
    }
}
