using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace mythos_frontend_dotnet.Models
{
    public class PurchaseMythrasRequest : IValidatableObject
    {
        public int MythrasPackageId { get; set; }

        [Required(ErrorMessage = "El número de tarjeta es obligatorio")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "El número de tarjeta debe tener exactamente 16 dígitos")]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "El número de tarjeta debe contener solo números")]
        public string CardNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre del titular es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre del titular no puede exceder 50 caracteres")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre del titular solo puede contener letras y espacios")]
        public string CardHolder { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de expiración es obligatoria")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{2}$", ErrorMessage = "La fecha de expiración debe estar en formato MM/YY")]
        public string ExpiryDate { get; set; } = string.Empty;

        [Required(ErrorMessage = "El CVC es obligatorio")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "El CVC debe tener 3 dígitos")]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "El CVC debe contener solo números")]
        public string Cvc { get; set; } = string.Empty;

        [Required(ErrorMessage = "El tipo de tarjeta es obligatorio")]
        [RegularExpression(@"^(Visa|Mastercard)$", ErrorMessage = "El tipo de tarjeta debe ser Visa o Mastercard")]
        public string CardType { get; set; } = string.Empty;

        [Required]
        public BillingAddress BillingAddress { get; set; } = new BillingAddress();

        // Validaciones complejas que no se pueden hacer con solo DataAnnotations
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Validar número de tarjeta con Luhn
            if (!LuhnCheck(CardNumber))
            {
                yield return new ValidationResult("El número de tarjeta no es válido.", new[] { nameof(CardNumber) });
            }

            // Validar fecha de expiración (no vencida)
            if (!TryParseExpiryDate(ExpiryDate, out DateTime expiryDate))
            {
                yield return new ValidationResult("La fecha de expiración es inválida o está en formato incorrecto.", new[] { nameof(ExpiryDate) });
            }
            else if (expiryDate < DateTime.UtcNow.Date)
            {
                yield return new ValidationResult("La tarjeta está vencida.", new[] { nameof(ExpiryDate) });
            }

            // Validar que el número de tarjeta coincida con el tipo
            if (CardType == "Visa" && !CardNumber.StartsWith("4"))
            {
                yield return new ValidationResult("El número de tarjeta no coincide con el tipo Visa.", new[] { nameof(CardNumber), nameof(CardType) });
            }
            else if (CardType == "Mastercard" && !CardNumber.StartsWith("5"))
            {
                yield return new ValidationResult("El número de tarjeta no coincide con el tipo Mastercard.", new[] { nameof(CardNumber), nameof(CardType) });
            }
        }

        private bool LuhnCheck(string cardNumber)
        {
            int sum = 0;
            bool alternate = false;
            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                int n = int.Parse(cardNumber[i].ToString());
                if (alternate)
                {
                    n *= 2;
                    if (n > 9)
                        n -= 9;
                }
                sum += n;
                alternate = !alternate;
            }
            return (sum % 10 == 0);
        }

        private bool TryParseExpiryDate(string expiry, out DateTime expiryDate)
        {
            expiryDate = DateTime.MinValue;
            if (string.IsNullOrWhiteSpace(expiry) || expiry.Length != 5 || expiry[2] != '/')
                return false;

            var parts = expiry.Split('/');
            if (!int.TryParse(parts[0], out int month) || !int.TryParse(parts[1], out int year))
                return false;

            year += 2000; // Asumimos formato YY

            try
            {
                expiryDate = new DateTime(year, month, DateTime.DaysInMonth(year, month));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public class BillingAddress
    {
        [Required(ErrorMessage = "La calle es obligatoria")]
        public string Street { get; set; } = string.Empty;

        [Required(ErrorMessage = "El código postal es obligatorio")]
        [MinLength(4, ErrorMessage = "El código postal debe tener al menos 4 caracteres")]
        public string PostalCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "La ciudad es obligatoria")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "El país es obligatorio")]
        public string Country { get; set; } = string.Empty;
    }
}


