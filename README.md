# CCash .NET API

## Installing

Not sure, just fork it i guess?

## How to use

First if you want to use commands that require a name or password (90% of the commands) you will need to input this by referring to the `current_user` property of the Communication class and changing it to a `new User(username, password)` where you put in the username and password as strings. It should be noted that `current_user.username` simply replaces any instances of `{name}` in the HTTP request, and what that means for you is that the username you're inputting is the contextually relevant one. If you're using AdminAddUser, you're inputting the username of the new user not your own. The request doesn't need your username

`SendRequest(string command, string receiver="", ulong _quantity=0, string body_text="")`
Therefore, you will need to input a case-sensitive command to the webserver (such as "GetBal", "SendFunds" etc.) and then you can select the inputs that your request needs from the optional parameters. You're a dev not a user so don't be a twat and decide to not fill in a parameter even if you need it for the request you picked.
Anyway here's an example, say you need SetBal which requires a username, password, and a quantity of bal to set. The username and password should already be contained in `current_user` and if not you're a twat. Go do it. You would call `SendRequest("SetBal", _quantity: 69)` quantity is the only parameter that accepts a non-string input, it accepts `ulong`. There is no overhead because there's no other data that is accepted to overhead for, cry about it

## CCash
CCash repository and set-up information can be found
[here](https://GitHub.com/EntireTwix/CCash).
