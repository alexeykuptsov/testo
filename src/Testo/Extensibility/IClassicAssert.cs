using JetBrains.Annotations;

namespace Testo.Extensibility
{
  public interface IClassicAssert
  {
    [AssertionMethod]
    [ContractAnnotation("condition:false=>void")]
    void IsTrue([AssertionCondition(AssertionConditionType.IS_TRUE)] bool condition, string assertion);

    [ContractAnnotation("=>halt")]
    void Fail(string assertion);
  }
}