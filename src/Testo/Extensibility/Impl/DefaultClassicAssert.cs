namespace Testo.Extensibility.Impl
{
    public class DefaultClassicAssert : IClassicAssert
    {
        public void IsTrue(bool condition, string assertion)
        {
            if (!condition)
                throw new AssertionException("Assertion is violated.\r\nAssertion: " + assertion);
        }

        public void Fail(string assertion)
        {
            throw new AssertionException("Assertion is violated.\r\nAssertion:" + assertion);
        }
    }
}