using HouseRentingSystem.Services;
using HouseRentingSystem.Services.Interfaces;
using HouseRentingSystem.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Tests.UnitTests
{
    public class AgentServiceTests : UnitTestsBase
    {
        private IAgentService agentService;
        public AgentServiceTests()
        {
            agentService = new AgentService(data);
        }

        [Fact]
        public void GetAgentId_ShouldReturnCorrectUserId()
        {
            //Arrange

            //Act
            int resultAgentId = this.agentService.GetAgentId(Agent.UserId);

            //Assert
            Assert.Equal(Convert.ToInt32(resultAgentId), Agent.Id);
        }

        [Fact]
        public async Task ExistsById_ShouldReturnTrue_WithValidIdAsync()
        {
            //Arrange

            //Act
            bool result = await this.agentService.ExistsById(Agent.UserId);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task AgentWithPhoneNumberExists_ShouldReturnTrue_WithValidPhoneNumber()
        {
            //Arrange

            //Act
            bool result = await this.agentService
                .AgentWithPhoneNumberExists("+359111111111");

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Create_ShouldAddNewAgent_WithValidData()
        {
            //Arrange
            int agentsCountBefore = this.data.Agents.Count();

            //Act
            await this.agentService.Create(Agent.UserId, Agent.PhoneNumber);

            //Assert
            Assert.Equal(agentsCountBefore + 1, this.data.Agents.Count());

            var newAgentId = this.agentService.GetAgentId(Agent.UserId);
            var newAgentInDb = this.data.Agents.First(a => a.Id == newAgentId);

            Assert.NotNull(newAgentInDb);
            Assert.Equal(Agent.UserId, newAgentInDb.UserId);
            Assert.Equal(Agent.PhoneNumber, newAgentInDb.PhoneNumber);
        }
    }
}
