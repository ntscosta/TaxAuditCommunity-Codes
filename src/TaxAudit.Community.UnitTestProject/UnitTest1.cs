using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxAuditCommunity.Domain.NFe;
using TaxAuditCommunity.Domain.NFe.Emit;
using TaxAuditCommunity.Domain.NFe.Ide;
using TaxAuditCommunity.Domain.NFe.TiposBasicos;
using TaxAuditCommunity.Domain.procNFe;

namespace TaxAudit.Community.UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            NFe _NFe = new NFe();
            _NFe.Id = "";
            _NFe.infNFe.Id = _NFe.Id;
            emit emit = new emit();
            emit.Id = 0;
            emit.enderEmitId = 0;
            Tendereco endereco = new Tendereco();
        }
    }
}
