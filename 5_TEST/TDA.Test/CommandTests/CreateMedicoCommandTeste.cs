using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDA.Domain.ChallengeContext.Commands.Inputs;

namespace TDA.Test.CommandTests
{
    [TestClass]
    public class CreateMedicoCommandTeste
    {
        private readonly CriaMedicoCommand _invalidCommand = new CriaMedicoCommand("marcus", "35478125645", "232434223");
        private readonly CriaMedicoCommand _validCommand = new CriaMedicoCommand("marcus", "35848857873", "232434223");
        public CreateMedicoCommandTeste()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        //RED GREEN REFACTOR
        [TestMethod]
        public void DadoCommandoInvalido()
        {
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void DadoCommandovalido()
        {
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}