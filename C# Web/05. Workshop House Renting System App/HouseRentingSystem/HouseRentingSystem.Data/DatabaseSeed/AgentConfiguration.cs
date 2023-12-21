using HouseRentingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRentingSystem.Data.DatabaseSeed
{
    public class AgentConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.HasData(SeedAgents());
        }

        private List<Agent> SeedAgents()
        {
            List<Agent> agents = new List<Agent>();

            Agent agent = new Agent()
            {
                Id = 1,
                PhoneNumber = "+359888888888",
                UserId = "dea12856-c198-4129-b3f3-b893d8395082"
            };

            Agent adminAgent = new Agent()
            {
                Id = 2,
                PhoneNumber = "+359123456789",
                UserId = "bcb4f072-ecca-43c9-ab26-c060c6f364e4"
            };

            agents.Add(agent);
            agents.Add(adminAgent);

            return agents;
        }
    }
}
