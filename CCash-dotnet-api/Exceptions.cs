using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCash_dotnet_api {
    class UserNotFoundException: Exception {
        public UserNotFoundException(string name) { }
    }
    class InvalidPasswordException: Exception {
        public InvalidPasswordException(string password, string name = "") { }
    }
    class InvalidRequestException: Exception { }
    class NameTooLongException: Exception {
        public NameTooLongException(string name) { }
    }
    class UserAlreadyExistsException: Exception {
        public UserAlreadyExistsException(string name) { }
    }
    class InsufficientFundsException: Exception {
        public InsufficientFundsException(string name, ulong amount) { }
    }
}
