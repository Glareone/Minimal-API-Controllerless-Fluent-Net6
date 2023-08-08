using System.ComponentModel.DataAnnotations;

namespace Chapter03_CORS_GlobalAPISettings.Options;

public class OptionsWithValidation
{
    public string ValidatedOptionValueNotNull { get; set; }

    [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$")]
    public string Email { get; set; }

    [Range(0, 1000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int NumericRange { get; set; }
}
