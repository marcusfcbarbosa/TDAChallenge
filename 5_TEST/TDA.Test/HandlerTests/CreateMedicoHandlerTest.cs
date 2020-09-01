using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDA.Domain.ChallengeContext.Commands.Inputs;
using TDA.Domain.ChallengeContext.Commands.Outputs;
using TDA.Domain.ChallengeContext.Handlers;
using TDA.Test.Repositorys;

namespace TDA.Test.HandlerTests
{
    [TestClass]
    public class CreateMedicoHandlerTest
    {
        private readonly CriaMedicoCommand _invalidCommand = new CriaMedicoCommand("marcus", "35478125645", "232434223");
        private readonly CriaMedicoCommand _validCommand = new CriaMedicoCommand("marcus", "21015511872", "232434223");
        private readonly MedicoHandler _handler = new MedicoHandler(new FakeMedicoRepository(), new FakeEspecialidadeRepository(), new FakeUserRepository(), new FakeMedicoEspecialidadeRespository());//Fake Repository
        //RED GREEN REFACTOR

        public CreateMedicoHandlerTest()
        {

        }
        [TestMethod]
        public void InputInvalidoDeveRetornarCommandResultFalse()
        {
            
            CommandResult result = (CommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(result.Success, false);
        }

        [TestMethod]
        public void InputValidoDeveRetornarCommandResultTrue()
        {
            CommandResult result = (CommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(result.Success, true);
        }
    }
}