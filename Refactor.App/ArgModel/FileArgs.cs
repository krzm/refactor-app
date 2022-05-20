using System.ComponentModel.DataAnnotations;
using CommandDotNet;

namespace Refactor.App;

public class FileArgs
    : IArgumentModel
{
    [Operand(nameof(FilePath)), Required, MaxLength(260)]
    public string? FilePath { get; set; }
}