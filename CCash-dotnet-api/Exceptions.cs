namespace CCash_dotnet_api {
    class UserNotFoundException: System.Exception {
        public UserNotFoundException(string name) { }
    }
    class InvalidPasswordException: System.Exception {
        public InvalidPasswordException(string password) { }
    }
    class InvalidRequestException: System.Exception { }
    class NameTooLongException: System.Exception {
        public NameTooLongException(string name) { }
    }
    class UserAlreadyExistsException: System.Exception {
        public UserAlreadyExistsException(string name) { }
    }
    class InsufficientFundsException: System.Exception {
        public InsufficientFundsException(string name, ulong amount) { }
    }
}
