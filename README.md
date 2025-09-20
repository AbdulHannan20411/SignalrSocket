📖 **Description of the Code**

This project demonstrates a real-time chat application built with ASP.NET Core SignalR and a simple HTML + JavaScript frontend.

🔹 Backend (C# SignalR Hub)

SignalrHub class extends the Hub base class from SignalR.

Key responsibilities:

Broadcasting Messages
SendMessage(string user, string message) sends a message from one user to all connected clients.

Private Messaging
SendMessageToUser(string user, string message) allows sending messages to a specific connected user.

User Management
A static Dictionary<int, string> Users stores connected users.
The GetAllUsers() method returns all current usernames, which the client uses to populate the user dropdown list.

The hub is mapped in Program.cs with:

app.MapHub<SignalrHub>("/chatHub");

🔹 Frontend (HTML, CSS, JavaScript)

The client is a single HTML page with inline styling and JavaScript.

UI Elements

Chat window: Displays real-time messages.

Message input box: Type a message to send.

Buttons:

Send to All: Broadcasts message to everyone.

Send to User: Sends message only to the selected user.

User dropdown: Displays all connected users for private chat.

Connection Setup

Uses SignalR JavaScript client (microsoft-signalr library).

Connects to the backend hub at:

http://localhost:5000/chathub?username=YourName


The username is collected with a prompt when the page loads.

Real-Time Updates

Subscribes to "ReceiveMessage" to display incoming messages in the chat window.

Calls SendMessageToAll or SendMessageToUser depending on the button clicked.

Calls GetAllUsers() from the hub to update the user dropdown.

The dropdown is refreshed automatically every 5 seconds.

Private Messaging

Select a user from the dropdown.

Enter a message.

Click Send to User → the hub routes the message only to the chosen user.

🔹 Features

✅ Real-time broadcast chat (send to all).
✅ Private chat with a selected user.
✅ User dropdown list that dynamically updates.
✅ Minimal inline HTML/CSS/JS, no extra frameworks needed.
✅ Works in local development with http://localhost.

🔹 Example Flow

Alice opens the app, enters Alice → connects.

Bob opens the app, enters Bob → connects.

Alice types “Hello everyone” → Bob sees it instantly.

Alice selects Bob in the dropdown → types “Hi Bob” → only Bob sees it.

Dropdown refresh ensures new users appear automatically.
