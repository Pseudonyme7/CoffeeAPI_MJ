public class SpecificationResult
{
    public bool IsSatisfied { get; }
    public string ErrorMessage { get; }

    private SpecificationResult(bool isSatisfied, string errorMessage = "")
    {
        IsSatisfied = isSatisfied;
        ErrorMessage = errorMessage;
    }

    public static SpecificationResult Success() => new SpecificationResult(true);
    public static SpecificationResult Failure(string message) => new SpecificationResult(false, message);
}
