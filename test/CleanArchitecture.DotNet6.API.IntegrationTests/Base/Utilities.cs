using CleanArchitecture.DotNet6.Domain.Entities;
using CleanArchitecture.DotNet6.Persistence;
using System;

namespace CleanArchitecture.DotNet6.API.IntegrationTests.Base
{
    public class Utilities
    {
        public static void InitializeDbForTests(CleanArchitectureDbContext context)
        {
            Guid concertGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            Guid musicalGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            Guid playGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            Guid conferenceGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            context.Categories.Add(new Category
            {
                CategoryId = concertGuid,
                Name = "Concerts"
            });
            context.Categories.Add(new Category
            {
                CategoryId = musicalGuid,
                Name = "Musicals"
            });
            context.Categories.Add(new Category
            {
                CategoryId = playGuid,
                Name = "Plays"
            });
            context.Categories.Add(new Category
            {
                CategoryId = conferenceGuid,
                Name = "Conferences"
            });

            context.SaveChanges();
        }
    }
}
