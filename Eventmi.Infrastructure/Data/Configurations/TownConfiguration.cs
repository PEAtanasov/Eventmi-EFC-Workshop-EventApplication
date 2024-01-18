using Eventmi.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventmi.Infrastructure.Data.Configurations
{
    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        private readonly string[] towns = new string[] { "Sofia", "Varna", "Plovdiv", "Bourgas" };
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            List<Town> entities = new List<Town>();
            int id = 1;
            foreach (var town in towns)
            {             
                entities.Add(new Town
                {
                    Id = id++,
                    Name=town
                });
            }

            builder.HasData(entities);
        }
    }
}
