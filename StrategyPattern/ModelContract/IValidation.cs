using System;

namespace ModelContract
{
    public interface IValidation<AnyType>
    {
        bool Validate(AnyType obj);
    }
}
