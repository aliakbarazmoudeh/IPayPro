using FluentValidation;

namespace TestCleanArchitecture.Domain.Validations
{
    public class PanelBankValidator : AbstractValidator<PanelBank>
    {
        // List of major Iranian banks (partial list for validation)
        private readonly string[] _validIranianBanks = new[]
        {
            "Melli", "Sepah", "Saderat", "Mellat", "Tejarat", "Refah", "Maskan",
            "Keshavarzi", "Postbank", "Saman", "Parsian", "Eghtesad Novin"
        };

        public PanelBankValidator()
        {
            // BankName validation
            RuleFor(x => x.BankName)
                .NotEmpty().WithMessage("Bank name is required")
                .Must(BeAValidIranianBank).WithMessage("Bank must be a valid Iranian bank")
                .MaximumLength(50).WithMessage("Bank name cannot exceed 50 characters");

            // Cardnum validation (Iranian bank cards are 16 digits)
            RuleFor(x => x.Cardnum)
                .NotEmpty().WithMessage("Card number is required")
                .Matches(@"^\d{16}$").WithMessage("Card number must be exactly 16 digits")
                .Must(BeValidIranianCardNumber).WithMessage("Invalid Iranian card number format");

            // Owner validation
            RuleFor(x => x.Owner)
                .NotEmpty().WithMessage("Owner name is required")
                .MaximumLength(100).WithMessage("Owner name cannot exceed 100 characters")
                .Matches(@"^[\p{L}\s]+$").WithMessage("Owner name can only contain letters and spaces"); // Supports Persian characters

            // AccountNumber validation
            RuleFor(x => x.AccountNumber)
                .NotEmpty().WithMessage("Account number is required")
                .Matches(@"^\d{10,16}$").WithMessage("Account number must be between 10 and 16 digits");

            // Shaba validation (Iranian IBAN)
            RuleFor(x => x.Shaba)
                .NotEmpty().WithMessage("Sheba number is required")
                .Matches(@"^IR\d{24}$").WithMessage("Sheba number must start with 'IR' followed by 24 digits")
                .Must(BeValidSheba).WithMessage("Invalid Sheba number");

            // Inventory validation
            RuleFor(x => x.Inventory)
                .GreaterThanOrEqualTo(0).WithMessage("Inventory cannot be negative");
        }

        private bool BeAValidIranianBank(string bankName)
        {
            if (string.IsNullOrWhiteSpace(bankName))
                return false;
            
            // Case-insensitive comparison with valid Iranian banks
            return _validIranianBanks.Any(b => b.Equals(bankName.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        private bool BeValidIranianCardNumber(string cardNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber) || cardNumber.Length != 16)
                return false;

            // Basic Luhn algorithm check for card number validation
            return IsValidLuhn(cardNumber);
        }

        private bool BeValidSheba(string shaba)
        {
            if (string.IsNullOrWhiteSpace(shaba) || shaba.Length != 26 || !shaba.StartsWith("IR"))
                return false;

            // Rearrange: Move first 4 characters (IR + check digits) to the end
            string rearranged = shaba.Substring(4) + shaba.Substring(0, 4);

            // Convert to numeric string: digits stay as-is, letters (I, R) convert to numbers (I=18, R=27)
            string numeric = string.Concat(rearranged.Select(c =>
            {
                if (char.IsDigit(c))
                    return c.ToString();
                else
                {
                    int value = char.ToUpper(c) - 'A' + 10; // A=10, B=11, ..., I=18, R=27
                    return value.ToString();
                }
            }));

            // Perform Mod 97 check
            return Mod97(numeric) == 1;
        }

        private bool IsValidLuhn(string number)
        {
            int sum = 0;
            bool alternate = false;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                int n = int.Parse(number[i].ToString());
                if (alternate)
                {
                    n *= 2;
                    if (n > 9) n -= 9;
                }
                sum += n;
                alternate = !alternate;
            }
            return (sum % 10 == 0);
        }

        private int Mod97(string number)
        {
            int remainder = 0;
            foreach (char c in number)
            {
                remainder = (remainder * 10 + (c - '0')) % 97;
            }
            return remainder;
        }
    }
}
