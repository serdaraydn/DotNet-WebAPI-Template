
namespace Entities.Exceptions
{
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException(String message) : base(message)
        {
            
        }
    }
}
