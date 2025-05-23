using System;

namespace QualAnalyzer.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
    public class CastCheckAttribute : Attribute
    {
        public Type TargetType { get; }
        public string? ErrorMessage { get; }

        public CastCheckAttribute(Type targetType, string? errorMessage = null)
        {
            TargetType = targetType;
            ErrorMessage = errorMessage;
        }

        public void Validate(object instance)
        {
            if (!TargetType.IsInstanceOfType(instance))
            {
                string message = ErrorMessage ?? $"Object cannot be cast to type {TargetType.FullName}.";
                throw new InvalidCastException(message);
            }
        }
    }
}
