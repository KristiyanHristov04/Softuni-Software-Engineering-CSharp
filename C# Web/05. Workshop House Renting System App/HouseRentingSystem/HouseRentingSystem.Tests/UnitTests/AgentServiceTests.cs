using HouseRentingSystem.Services;
using HouseRentingSystem.Services.Interfaces;
using HouseRentingSystem.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
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
            int resultAgentId = agentService.GetAgentId(Agent.UserId);

            //Assert
            Assert.Equal(Convert.ToInt32(resultAgentId), Agent.Id);
        }
    }
}
