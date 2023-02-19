using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GorgesMusic.Core.Validators;

internal class AllowedFileExtensionsAttribute : ValidationAttribute
{
    private readonly string[] _extensions;
    public AllowedFileExtensionsAttribute(string[] extensions)
    {
        this._extensions = extensions;
    }
   
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var file = value as IFormFile;
        if (file != null)
        {
            var extension = Path.GetExtension(file.FileName);
            if (!_extensions.Contains(extension.ToLower()))
            {
                return new ValidationResult(GetErrorMessage());
            }
        }

        return ValidationResult.Success;
    }

    public string GetErrorMessage()
    {
        return $"This file extension is not allowed!";
    }
}
