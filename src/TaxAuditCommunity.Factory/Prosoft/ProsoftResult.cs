namespace TaxAuditCommunity.Factory.Prosoft
{
    public class ProsoftResult
    {
        private static readonly ProsoftResult _success = new ProsoftResult { Succeeded = true };

        public bool Succeeded { get; protected set; }

        public static ProsoftResult Success => _success;

        public static ProsoftResult Failed()
        {
            var result = new ProsoftResult
            {
                Succeeded = false

            };
            return result;
        }
    }
}